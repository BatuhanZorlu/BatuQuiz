namespace AbbreviationQuiz.Api.Models;

public class Abbreviation
{
    public int Id { get; set; }
    public string Short { get; set; } = string.Empty;
    public string Full { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string Level { get; set; } = "Junior";
}
