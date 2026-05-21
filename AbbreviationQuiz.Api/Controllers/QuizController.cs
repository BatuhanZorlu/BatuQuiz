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
    public async Task<IActionResult> GetRandom()
    {
        var count = await _db.Abbreviations.CountAsync();
        if (count == 0) return NotFound("No abbreviations in database.");

        var skip = Random.Shared.Next(count);
        var item = await _db.Abbreviations.Skip(skip).FirstAsync();
        return Ok(item);
    }
}
