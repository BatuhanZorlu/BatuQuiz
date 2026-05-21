import { useState, useEffect } from "react";
import { fetchLeaderboard } from "../api/client";
import type { ScoreEntry } from "../api/client";

const MEDALS = ["🥇", "🥈", "🥉"];

function formatDate(iso: string) {
  return new Date(iso).toLocaleDateString("tr-TR", {
    day: "numeric",
    month: "short",
    hour: "2-digit",
    minute: "2-digit",
  });
}

export default function ScoreboardPage() {
  const [scores, setScores] = useState<ScoreEntry[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  const load = async () => {
    setLoading(true);
    setError("");
    try {
      setScores(await fetchLeaderboard());
    } catch {
      setError("Skor tablosu yüklenemedi.");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => { load(); }, []);

  return (
    <div className="page sb-page">
      <div className="sb-header">
        <h2 className="sb-title">Skor Tablosu</h2>
        <button className="sb-refresh-btn" onClick={load} disabled={loading}>
          ↻ Yenile
        </button>
      </div>

      {loading ? (
        <div className="loading-spinner"><div className="spinner" /></div>
      ) : error ? (
        <div className="card error-card"><p>{error}</p></div>
      ) : scores.length === 0 ? (
        <div className="card error-card">
          <p>Henüz skor yok. İlk yarışan sen ol!</p>
        </div>
      ) : (
        <div className="sb-table-wrap">
          <table className="sb-table">
            <thead>
              <tr>
                <th>#</th>
                <th>İsim</th>
                <th>Doğru</th>
                <th>Yanlış</th>
                <th>Doğruluk</th>
                <th>Tarih</th>
              </tr>
            </thead>
            <tbody>
              {scores.map((s, i) => (
                <tr key={s.id} className={i < 3 ? "sb-top" : ""}>
                  <td className="sb-rank">
                    {i < 3 ? MEDALS[i] : i + 1}
                  </td>
                  <td className="sb-name">{s.playerName}</td>
                  <td className="sb-correct">{s.correct}</td>
                  <td className="sb-wrong">{s.wrong}</td>
                  <td className="sb-accuracy">%{s.accuracy}</td>
                  <td className="sb-date">{formatDate(s.playedAt)}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}
