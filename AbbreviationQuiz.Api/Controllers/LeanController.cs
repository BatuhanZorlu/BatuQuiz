using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbbreviationQuiz.Api.Data;

namespace AbbreviationQuiz.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeanController : ControllerBase
{
    private readonly AppDbContext _db;

    public LeanController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("question")]
    public async Task<IActionResult> GetQuestion([FromQuery] int options = 6)
    {
        var allTerms = await _db.LeanTerms.ToListAsync();
        if (allTerms.Count < options)
            return BadRequest("Not enough terms in the database.");

        var rng = Random.Shared;
        var correct = allTerms[rng.Next(allTerms.Count)];

        var wrongPool = allTerms.Where(t => t.Id != correct.Id).ToList();
        var wrongCount = options - 1;
        var wrongOptions = wrongPool.OrderBy(_ => rng.Next()).Take(wrongCount).Select(t => t.Definition).ToList();

        var shuffledOptions = wrongOptions.Append(correct.Definition).OrderBy(_ => rng.Next()).ToList();

        return Ok(new LeanQuestionDto(
            correct.Id,
            correct.Term.ToUpper(),
            correct.Category,
            correct.Definition,
            shuffledOptions
        ));
    }
}

public record LeanQuestionDto(
    int Id,
    string Term,
    string Category,
    string CorrectDefinition,
    List<string> Options
);
