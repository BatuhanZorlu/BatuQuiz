using Microsoft.EntityFrameworkCore;
using AbbreviationQuiz.Api.Models;

namespace AbbreviationQuiz.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Abbreviation> Abbreviations => Set<Abbreviation>();
    public DbSet<Score> Scores => Set<Score>();
}
