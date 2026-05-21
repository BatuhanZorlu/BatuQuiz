using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbbreviationQuiz.Api.Data;
using AbbreviationQuiz.Api.Models;

namespace AbbreviationQuiz.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AbbreviationsController : ControllerBase
{
    private readonly AppDbContext _db;

    public AbbreviationsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? level)
    {
        var query = _db.Abbreviations.AsQueryable();

        if (!string.IsNullOrWhiteSpace(level))
            query = query.Where(a => a.Level == level);

        var items = await query.OrderBy(a => a.Short).ToListAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAbbreviationDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Short) || string.IsNullOrWhiteSpace(dto.Full))
            return BadRequest("Short and Full fields are required.");

        var item = new Abbreviation
        {
            Short = dto.Short.Trim().ToUpper(),
            Full = dto.Full.Trim(),
            Category = string.IsNullOrWhiteSpace(dto.Category) ? null : dto.Category.Trim(),
            Level = string.IsNullOrWhiteSpace(dto.Level) ? "Junior" : dto.Level.Trim()
        };

        _db.Abbreviations.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }
}

public record CreateAbbreviationDto(string Short, string Full, string? Category, string? Level);
