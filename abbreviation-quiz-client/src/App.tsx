import { useState } from "react";
import QuizPage from "./pages/QuizPage";
import AddPage from "./pages/AddPage";
import RacePage from "./pages/RacePage";
import ScoreboardPage from "./pages/ScoreboardPage";
import LeanPage from "./pages/LeanPage";
import "./index.css";

type Tab = "quiz" | "race" | "scoreboard" | "lean" | "add";

export default function App() {
  const [activeTab, setActiveTab] = useState<Tab>("quiz");
  const [isRacing, setIsRacing] = useState(false);

  const switchTab = (tab: Tab) => {
    if (isRacing && tab !== "race") return;
    setActiveTab(tab);
  };

  return (
    <div className="app">
      <header className="app-header">
        <div className="header-inner">
          <div className="logo">
            <span className="logo-bracket">&lt;</span>
            <span className="logo-text">BatuQuiz</span>
            <span className="logo-bracket">/&gt;</span>
          </div>
          <nav className="tab-nav">
            <button
              className={`tab-btn ${activeTab === "quiz" ? "active" : ""} ${isRacing ? "locked" : ""}`}
              onClick={() => switchTab("quiz")}
            >
              Quiz
            </button>
            <button
              className={`tab-btn ${activeTab === "race" ? "active" : ""}`}
              onClick={() => switchTab("race")}
            >
              ⏱ Yarış
            </button>
            <button
              className={`tab-btn ${activeTab === "scoreboard" ? "active" : ""} ${isRacing ? "locked" : ""}`}
              onClick={() => switchTab("scoreboard")}
            >
              🏆 Skor
            </button>
            <button
              className={`tab-btn ${activeTab === "lean" ? "active" : ""} ${isRacing ? "locked" : ""}`}
              onClick={() => switchTab("lean")}
            >
              🏭 Lean
            </button>
            <button
              className={`tab-btn ${activeTab === "add" ? "active" : ""} ${isRacing ? "locked" : ""}`}
              onClick={() => switchTab("add")}
            >
              Kelime Ekle
            </button>
          </nav>
        </div>
      </header>

      <main className="app-main">
        {activeTab === "quiz" && <QuizPage />}
        {activeTab === "race" && <RacePage onRacingChange={setIsRacing} />}
        {activeTab === "scoreboard" && <ScoreboardPage />}
        {activeTab === "lean" && <LeanPage />}
        {activeTab === "add" && <AddPage />}
      </main>
    </div>
  );
}
