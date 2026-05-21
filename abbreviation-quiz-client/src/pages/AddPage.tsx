import { useState } from "react";
import { createAbbreviation } from "../api/client";

type FeedbackType = "success" | "error" | null;

export default function AddPage() {
  const [short, setShort] = useState("");
  const [full, setFull] = useState("");
  const [category, setCategory] = useState("");
  const [feedback, setFeedback] = useState<{ type: FeedbackType; message: string }>({
    type: null,
    message: "",
  });
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!short.trim() || !full.trim()) return;

    setLoading(true);
    setFeedback({ type: null, message: "" });

    try {
      await createAbbreviation({
        short: short.trim(),
        full: full.trim(),
        category: category.trim() || undefined,
      });
      setFeedback({ type: "success", message: `"${short.toUpperCase()}" başarıyla eklendi!` });
      setShort("");
      setFull("");
      setCategory("");
    } catch (err) {
      const message = err instanceof Error ? err.message : "Bir hata oluştu.";
      setFeedback({ type: "error", message });
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="page add-page">
      <div className="card add-card">
        <h2 className="add-title">Yeni Kısaltma Ekle</h2>
        <p className="add-subtitle">Quiz veritabanını yeni girişlerle genişlet.</p>

        <form className="add-form" onSubmit={handleSubmit}>
          <div className="form-field">
            <label htmlFor="short">Kısaltma</label>
            <input
              id="short"
              type="text"
              placeholder="örn. SSH"
              value={short}
              onChange={(e) => setShort(e.target.value)}
              required
            />
          </div>

          <div className="form-field">
            <label htmlFor="full">Açılım</label>
            <input
              id="full"
              type="text"
              placeholder="örn. Secure Shell"
              value={full}
              onChange={(e) => setFull(e.target.value)}
              required
            />
          </div>

          <div className="form-field">
            <label htmlFor="category">Kategori <span className="optional">(isteğe bağlı)</span></label>
            <input
              id="category"
              type="text"
              placeholder="örn. Ağ"
              value={category}
              onChange={(e) => setCategory(e.target.value)}
            />
          </div>

          {feedback.type && (
            <div className={`feedback-banner ${feedback.type}`}>
              {feedback.type === "success" ? "✓" : "✗"} {feedback.message}
            </div>
          )}

          <button type="submit" className="submit-btn full-width" disabled={loading}>
            {loading ? "Ekleniyor..." : "Kısaltma Ekle"}
          </button>
        </form>
      </div>
    </div>
  );
}
