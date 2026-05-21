namespace AbbreviationQuiz.Api.Models;

public class Score
{
    public int Id { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public int Correct { get; set; }
    public int Wrong { get; set; }
    public int Total { get; set; }
    public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
}
