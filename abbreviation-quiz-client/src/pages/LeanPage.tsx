import { useState, useEffect, useRef, useCallback } from "react";

interface LeanQuestion {
  id: number;
  term: string;
  category: string;
  correctDefinition: string;
  options: string[];
}

type AnswerState = "idle" | "correct" | "wrong";

export default function LeanPage() {
  const [question, setQuestion] = useState<LeanQuestion | null>(null);
  const [loading, setLoading] = useState(true);
  const [score, setScore] = useState({ correct: 0, total: 0 });
  const [selectedOption, setSelectedOption] = useState<string | null>(null);
  const [answerState, setAnswerState] = useState<AnswerState>("idle");
  const timerRef = useRef<ReturnType<typeof setTimeout> | null>(null);

  const fetchQuestion = useCallback(async () => {
    setLoading(true);
    setSelectedOption(null);
    setAnswerState("idle");
    try {
      const res = await fetch("/api/lean/question?options=6");
      if (!res.ok) throw new Error("fetch failed");
      const data: LeanQuestion = await res.json();
      setQuestion(data);
    } catch {
      setQuestion(null);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchQuestion();
    return () => {
      if (timerRef.current) clearTimeout(timerRef.current);
    };
  }, [fetchQuestion]);

  const handleOptionClick = (option: string) => {
    if (answerState !== "idle" || !question) return;

    setSelectedOption(option);
    const isCorrect = option === question.correctDefinition;
    setAnswerState(isCorrect ? "correct" : "wrong");
    setScore((s) => ({
      correct: s.correct + (isCorrect ? 1 : 0),
      total: s.total + 1,
    }));

    timerRef.current = setTimeout(fetchQuestion, 1500);
  };

  const getOptionClass = (option: string): string => {
    if (answerState === "idle") return "option-btn";
    if (option === question?.correctDefinition) return "option-btn correct";
    if (option === selectedOption && answerState === "wrong") return "option-btn wrong";
    return "option-btn";
  };

  const accuracy = score.total > 0 ? Math.round((score.correct / score.total) * 100) : 0;

  return (
    <div className="page">
      <div className="score-bar">
        <span className="score-label">Skor</span>
        <span className="score-value">{score.correct}/{score.total}</span>
        {score.total > 0 && <span className="accuracy">%{accuracy} doğruluk</span>}
      </div>

      {loading ? (
        <div className="loading-spinner"><div className="spinner" /></div>
      ) : !question ? (
        <div className="card error-card"><p>Soru yüklenemedi. Lütfen tekrar dene.</p></div>
      ) : (
        <div className="card">
          <span className="category-badge">{question.category}</span>
          <div className="abbreviation-display">{question.term}</div>
          <p className="prompt-text">Bu Lean teriminin tanımı nedir?</p>
          <div className="options-grid">
            {question.options.map((option) => (
              <button
                key={option}
                className={getOptionClass(option)}
                onClick={() => handleOptionClick(option)}
                disabled={answerState !== "idle"}
              >
                {option}
              </button>
            ))}
          </div>
        </div>
      )}
    </div>
  );
}
