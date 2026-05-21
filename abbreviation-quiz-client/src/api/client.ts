const BASE = "/api";

export interface Abbreviation {
  id: number;
  short: string;
  full: string;
  category?: string;
}

export async function fetchRandom(): Promise<Abbreviation> {
  const res = await fetch(`${BASE}/quiz/random`);
  if (!res.ok) throw new Error("Failed to fetch question");
  return res.json();
}

export async function fetchAll(): Promise<Abbreviation[]> {
  const res = await fetch(`${BASE}/abbreviations`);
  if (!res.ok) throw new Error("Failed to fetch abbreviations");
  return res.json();
}

export interface ScoreEntry {
  id: number;
  playerName: string;
  correct: number;
  wrong: number;
  total: number;
  accuracy: number;
  playedAt: string;
}

export async function fetchLeaderboard(): Promise<ScoreEntry[]> {
  const res = await fetch(`${BASE}/scores/leaderboard`);
  if (!res.ok) throw new Error("Skor tablosu yüklenemedi");
  return res.json();
}

export async function submitScore(data: {
  playerName: string;
  correct: number;
  wrong: number;
  total: number;
}): Promise<void> {
  const res = await fetch(`${BASE}/scores`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!res.ok) throw new Error("Skor kaydedilemedi");
}

export async function createAbbreviation(data: {
  short: string;
  full: string;
  category?: string;
}): Promise<Abbreviation> {
  const res = await fetch(`${BASE}/abbreviations`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!res.ok) {
    const text = await res.text();
    throw new Error(text || "Failed to create abbreviation");
  }
  return res.json();
}
