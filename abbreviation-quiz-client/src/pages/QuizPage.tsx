import { useState, useEffect, useRef, useCallback } from "react";
import { fetchRandom } from "../api/client";
import type { Abbreviation } from "../api/client";

type Status = "idle" | "correct" | "wrong";

const LEVELS = ["Tümü", "Stajyer", "Junior", "Mid", "Senior"] as const;
type Level = (typeof LEVELS)[number];
const LEVEL_KEY = "quiz_level";

export default function QuizPage() {
  const [level, setLevel] = useState<Level>(
    () => (localStorage.getItem(LEVEL_KEY) as Level) ?? "Tümü"
  );
  const [question, setQuestion] = useState<Abbreviation | null>(null);
  const [answer, setAnswer] = useState("");
  const [status, setStatus] = useState<Status>("idle");
  const [score, setScore] = useState({ correct: 0, total: 0 });
  const [loading, setLoading] = useState(true);
  const inputRef = useRef<HTMLInputElement>(null);
  const timerRef = useRef<ReturnType<typeof setTimeout> | null>(null);

  const loadNext = useCallback(async (selectedLevel: Level) => {
    setLoading(true);
    setStatus("idle");
    setAnswer("");
    try {
      const q = await fetchRandom(selectedLevel === "Tümü" ? undefined : selectedLevel);
      setQuestion(q);
    } catch {
      setQuestion(null);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    loadNext(level);
  }, [loadNext, level]);

  useEffect(() => {
    if (!loading && status === "idle") {
      inputRef.current?.focus();
    }
  }, [loading, status]);

  useEffect(() => {
    return () => {
      if (timerRef.current) clearTimeout(timerRef.current);
    };
  }, []);

  const handleLevelChange = (l: Level) => {
    if (timerRef.current) clearTimeout(timerRef.current);
    localStorage.setItem(LEVEL_KEY, l);
    setLevel(l);
    setScore({ correct: 0, total: 0 });
    setStatus("idle");
  };

  const submit = () => {
    if (!question || status !== "idle") return;
    const normalize = (s: string) => s.trim().toLowerCase().replace(/[-]/g, " ").replace(/\s+/g, " ");
    const trimmed = normalize(answer);
    if (!trimmed) return;

    const isCorrect = trimmed === normalize(question.full);

    setStatus(isCorrect ? "correct" : "wrong");
    setScore((s) => ({
      correct: s.correct + (isCorrect ? 1 : 0),
      total: s.total + 1,
    }));

    const delay = isCorrect ? 1200 : 2500;
    timerRef.current = setTimeout(() => loadNext(level), delay);
  };

  const handleKeyDown = (e: React.KeyboardEvent) => {
    if (e.key === "Enter") submit();
  };

  const accuracy =
    score.total > 0 ? Math.round((score.correct / score.total) * 100) : 0;

  return (
    <div className="page quiz-page">
      <div className="level-selector">
        {LEVELS.map((l) => (
          <button
            key={l}
            className={`level-pill${level === l ? " active" : ""}`}
            onClick={() => handleLevelChange(l)}
          >
            {l}
          </button>
        ))}
      </div>

      <div className="score-bar">
        <span className="score-label">Skor</span>
        <span className="score-value">
          {score.correct}/{score.total}
        </span>
        {score.total > 0 && (
          <span className="accuracy">%{accuracy} doğruluk</span>
        )}
      </div>

      {loading ? (
        <div className="loading-spinner">
          <div className="spinner" />
        </div>
      ) : !question ? (
        <div className="card error-card">
          <p>Soru bulunamadı. Önce kelime ekle.</p>
        </div>
      ) : (
        <div className={`card quiz-card ${status}`}>
          {question.category && (
            <span className="category-badge">{question.category}</span>
          )}

          <div className="abbreviation-display">{question.short}</div>

          <p className="prompt-text">Bu kısaltmanın açılımı nedir?</p>

          {status === "idle" && (
            <div className="input-group">
              <input
                ref={inputRef}
                className="answer-input"
                type="text"
                placeholder="Açılımını yaz..."
                value={answer}
                onChange={(e) => setAnswer(e.target.value)}
                onKeyDown={handleKeyDown}
                disabled={status !== "idle"}
              />
              <button className="submit-btn" onClick={submit}>
                Kontrol Et
              </button>
            </div>
          )}

          {status === "correct" && (
            <div className="feedback correct-feedback">
              <span className="feedback-icon">✓</span>
              <span>Doğru!</span>
            </div>
          )}

          {status === "wrong" && (
            <div className="feedback wrong-feedback">
              <span className="feedback-icon">✗</span>
              <div>
                <p className="wrong-label">Yanlış. Doğru cevap:</p>
                <p className="correct-answer">{question.full}</p>
              </div>
            </div>
          )}
        </div>
      )}
    </div>
  );
}
