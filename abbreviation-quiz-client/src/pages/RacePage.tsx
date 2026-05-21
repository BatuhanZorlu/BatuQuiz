import { useState, useEffect, useRef, useCallback } from "react";
import { fetchRandom, submitScore } from "../api/client";
import type { Abbreviation } from "../api/client";

const DURATION = 60;
const BEST_KEY = "race_best";
const NAME_KEY = "race_player_name";
const LEVEL_KEY = "race_level";

const LEVELS = ["Tümü", "Stajyer", "Junior", "Mid", "Senior"] as const;
type Level = (typeof LEVELS)[number];

type Phase = "idle" | "playing" | "finished";
type Status = "idle" | "correct" | "wrong";

interface Result {
  correct: number;
  wrong: number;
  total: number;
}

function getBest(): number {
  return parseInt(localStorage.getItem(BEST_KEY) ?? "0", 10);
}

function saveBest(score: number) {
  if (score > getBest()) localStorage.setItem(BEST_KEY, String(score));
}

interface Props {
  onRacingChange: (racing: boolean) => void;
}

export default function RacePage({ onRacingChange }: Props) {
  const [phase, setPhase] = useState<Phase>("idle");
  const [level, setLevel] = useState<Level>(
    () => (localStorage.getItem(LEVEL_KEY) as Level) ?? "Tümü"
  );
  const [playerName, setPlayerName] = useState(() => localStorage.getItem(NAME_KEY) ?? "");
  const [question, setQuestion] = useState<Abbreviation | null>(null);
  const [answer, setAnswer] = useState("");
  const [status, setStatus] = useState<Status>("idle");
  const [timeLeft, setTimeLeft] = useState(DURATION);
  const [result, setResult] = useState<Result>({ correct: 0, wrong: 0, total: 0 });
  const [best, setBest] = useState(getBest);
  const [loading, setLoading] = useState(false);
  const [nameError, setNameError] = useState("");

  const resultRef = useRef<Result>({ correct: 0, wrong: 0, total: 0 });
  const timerRef = useRef<ReturnType<typeof setInterval> | null>(null);
  const feedbackTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
  const inputRef = useRef<HTMLInputElement>(null);
  const levelRef = useRef<Level>(level);

  useEffect(() => {
    levelRef.current = level;
  }, [level]);

  const loadQuestion = useCallback(async () => {
    setLoading(true);
    setAnswer("");
    setStatus("idle");
    try {
      const l = levelRef.current;
      const q = await fetchRandom(l === "Tümü" ? undefined : l);
      setQuestion(q);
    } finally {
      setLoading(false);
    }
  }, []);

  const finish = useCallback(async () => {
    if (timerRef.current) clearInterval(timerRef.current);
    if (feedbackTimer.current) clearTimeout(feedbackTimer.current);
    const r = resultRef.current;
    setResult({ ...r });
    saveBest(r.correct);
    setBest(getBest());
    setPhase("finished");
    onRacingChange(false);

    try {
      await submitScore({
        playerName: localStorage.getItem(NAME_KEY) ?? "Anonim",
        correct: r.correct,
        wrong: r.wrong,
        total: r.total,
      });
    } catch {
      // skor kaydedilemese bile oyun devam eder
    }
  }, []);

  const start = useCallback(async () => {
    const name = playerName.trim();
    if (!name) {
      setNameError("Lütfen adını gir.");
      return;
    }
    setNameError("");
    localStorage.setItem(NAME_KEY, name);

    resultRef.current = { correct: 0, wrong: 0, total: 0 };
    setResult({ correct: 0, wrong: 0, total: 0 });
    setTimeLeft(DURATION);
    setPhase("playing");
    onRacingChange(true);
    await loadQuestion();

    timerRef.current = setInterval(() => {
      setTimeLeft((t) => {
        if (t <= 1) {
          finish();
          return 0;
        }
        return t - 1;
      });
    }, 1000);
  }, [playerName, loadQuestion, finish]);

  useEffect(() => {
    if (phase === "playing" && !loading && status === "idle") {
      inputRef.current?.focus();
    }
  }, [phase, loading, status]);

  useEffect(() => {
    return () => {
      if (timerRef.current) clearInterval(timerRef.current);
      if (feedbackTimer.current) clearTimeout(feedbackTimer.current);
    };
  }, []);

  useEffect(() => {
    if (phase !== "playing") return;

    const handleBeforeUnload = (e: BeforeUnloadEvent) => {
      e.preventDefault();
    };

    const handleVisibilityChange = () => {
      if (document.hidden) finish();
    };

    window.addEventListener("beforeunload", handleBeforeUnload);
    document.addEventListener("visibilitychange", handleVisibilityChange);

    return () => {
      window.removeEventListener("beforeunload", handleBeforeUnload);
      document.removeEventListener("visibilitychange", handleVisibilityChange);
    };
  }, [phase, finish]);

  const submit = () => {
    if (!question || status !== "idle" || phase !== "playing") return;
    const normalize = (s: string) =>
      s.trim().toLowerCase().replace(/[-]/g, " ").replace(/\s+/g, " ");
    const trimmed = normalize(answer);
    if (!trimmed) return;

    const isCorrect = trimmed === normalize(question.full);
    const next = { ...resultRef.current };
    next.total += 1;
    if (isCorrect) next.correct += 1;
    else next.wrong += 1;
    resultRef.current = next;

    setStatus(isCorrect ? "correct" : "wrong");

    const delay = isCorrect ? 600 : 1400;
    feedbackTimer.current = setTimeout(() => loadQuestion(), delay);
  };

  const handleKeyDown = (e: React.KeyboardEvent) => {
    if (e.key === "Enter") submit();
  };

  const handleLevelChange = (l: Level) => {
    localStorage.setItem(LEVEL_KEY, l);
    setLevel(l);
  };

  const pct = (timeLeft / DURATION) * 100;
  const timerColor =
    timeLeft > 20 ? "var(--accent)" : timeLeft > 10 ? "#f59e0b" : "var(--wrong)";

  if (phase === "idle") {
    return (
      <div className="page race-page">
        <div className="card race-idle-card">
          <div className="race-icon">⏱</div>
          <h2 className="race-title">60 Saniyelik Yarış</h2>
          <p className="race-desc">
            Süre dolmadan mümkün olduğunca çok kısaltmanın açılımını yaz.
            Sonuç skor tablosuna kaydedilecek.
          </p>

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

          <div className="rules-box">
            <p className="rules-title">📋 Kurallar</p>
            <ul className="rules-list">
              <li>⏱ 60 saniye boyunca kısaltmaların açılımını yaz</li>
              <li>🚫 Başka sekmeye geçmek yasak — yarış anında biter</li>
              <li>🔍 İnternetten veya başka kaynaktan bakmak yasak</li>
              <li>🤝 Yardımlaşmak yasak, bireysel yarışma</li>
              <li>✏️ Tire (-) ve boşluk kullanımı serbest</li>
              <li>🏆 En fazla doğru cevap veren kazanır</li>
            </ul>
          </div>

          <div className="name-field">
            <label htmlFor="player-name">Adın</label>
            <input
              id="player-name"
              type="text"
              placeholder="Adını gir..."
              value={playerName}
              onChange={(e) => { setPlayerName(e.target.value); setNameError(""); }}
              onKeyDown={(e) => e.key === "Enter" && start()}
              maxLength={30}
            />
            {nameError && <span className="name-error">{nameError}</span>}
          </div>

          {best > 0 && (
            <p className="race-best-label">
              En iyi: <span className="race-best-value">{best} doğru</span>
            </p>
          )}
          <button className="submit-btn full-width race-start-btn" onClick={start}>
            Başla
          </button>
        </div>
      </div>
    );
  }

  if (phase === "finished") {
    const accuracy =
      result.total > 0 ? Math.round((result.correct / result.total) * 100) : 0;
    const isNewBest = result.correct > 0 && result.correct >= best;

    return (
      <div className="page race-page">
        <div className="card race-result-card">
          {isNewBest && <div className="new-best-badge">Yeni Rekor!</div>}
          <h2 className="race-title">Süre doldu!</h2>
          <p className="race-player-name">{localStorage.getItem(NAME_KEY)}</p>

          <div className="result-grid">
            <div className="result-stat">
              <span className="result-stat-value correct-color">{result.correct}</span>
              <span className="result-stat-label">Doğru</span>
            </div>
            <div className="result-stat">
              <span className="result-stat-value wrong-color">{result.wrong}</span>
              <span className="result-stat-label">Yanlış</span>
            </div>
            <div className="result-stat">
              <span className="result-stat-value">{result.total}</span>
              <span className="result-stat-label">Toplam</span>
            </div>
            <div className="result-stat">
              <span className="result-stat-value accent-color">%{accuracy}</span>
              <span className="result-stat-label">Doğruluk</span>
            </div>
          </div>

          <p className="race-best-label">
            En iyi: <span className="race-best-value">{best} doğru</span>
          </p>

          <button className="submit-btn full-width race-start-btn" onClick={start}>
            Tekrar Oyna
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="page race-page">
      <div className="race-timer-bar-wrap">
        <div
          className="race-timer-bar"
          style={{ width: `${pct}%`, background: timerColor }}
        />
      </div>

      <div className="race-hud">
        <span className="race-time" style={{ color: timerColor }}>
          {timeLeft}s
        </span>
        <span className="race-hud-name">{localStorage.getItem(NAME_KEY)}</span>
        <span className="race-score-inline">
          ✓ {resultRef.current.correct} &nbsp; ✗ {resultRef.current.wrong}
        </span>
      </div>

      {loading ? (
        <div className="loading-spinner"><div className="spinner" /></div>
      ) : !question ? (
        <div className="card error-card"><p>Soru yüklenemedi.</p></div>
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
