using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbbreviationQuiz.Api.Data;
using AbbreviationQuiz.Api.Models;

namespace AbbreviationQuiz.Api.Controllers;

[ApiController]
[Route("api/scores")]
public class ScoresController : ControllerBase
{
    private readonly AppDbContext _db;

    public ScoresController(AppDbContext db) => _db = db;

    [HttpGet("leaderboard")]
    public async Task<IActionResult> Leaderboard()
    {
        var scores = await _db.Scores
            .OrderByDescending(s => s.Correct)
            .ThenBy(s => s.PlayedAt)
            .Take(20)
            .Select(s => new
            {
                s.Id,
                s.PlayerName,
                s.Correct,
                s.Wrong,
                s.Total,
                Accuracy = s.Total > 0 ? (int)Math.Round((double)s.Correct / s.Total * 100) : 0,
                s.PlayedAt
            })
            .ToListAsync();

        return Ok(scores);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateScoreRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.PlayerName))
            return BadRequest("İsim gerekli.");

        var score = new Score
        {
            PlayerName = req.PlayerName.Trim(),
            Correct = req.Correct,
            Wrong = req.Wrong,
            Total = req.Total,
            PlayedAt = DateTime.UtcNow
        };

        _db.Scores.Add(score);
        await _db.SaveChangesAsync();
        return Ok(score);
    }
}

public record CreateScoreRequest(string PlayerName, int Correct, int Wrong, int Total);
