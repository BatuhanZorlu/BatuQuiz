using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbbreviationQuiz.Api.Data;

namespace AbbreviationQuiz.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly AppDbContext _db;

    public QuizController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandom([FromQuery] string? level)
    {
        var query = _db.Abbreviations.AsQueryable();

        if (!string.IsNullOrWhiteSpace(level))
            query = query.Where(a => a.Level == level);

        var count = await query.CountAsync();
        if (count == 0) return NotFound("No abbreviations found.");

        var skip = Random.Shared.Next(count);
        var item = await query.Skip(skip).FirstAsync();
        return Ok(item);
    }
}
