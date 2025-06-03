using Microsoft.EntityFrameworkCore;
using Kris.Models;

namespace Kris.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<YearOfStudy> YearsOfStudy => Set<YearOfStudy>();
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Competition> Competitions => Set<Competition>();
    public DbSet<Registration> Registrations => Set<Registration>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Association> Associations => Set<Association>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure unique constraint for Registration - one registration per student
        modelBuilder.Entity<Registration>()
            .HasIndex(r => r.StudentId)
            .IsUnique();
    }
}
