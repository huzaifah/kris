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

        // Seed Years of Study
        modelBuilder.Entity<YearOfStudy>().HasData(
            new YearOfStudy { Id = 1, Name = "Form 1" },
            new YearOfStudy { Id = 2, Name = "Form 2" },
            new YearOfStudy { Id = 3, Name = "Form 3" },
            new YearOfStudy { Id = 4, Name = "Form 4" }
        );

        // Seed Classes for each Year
        modelBuilder.Entity<Class>().HasData(
            new Class { Id = 1, Name = "1 Red", YearOfStudyId = 1 },
            new Class { Id = 2, Name = "1 Blue", YearOfStudyId = 1 },
            new Class { Id = 3, Name = "1 Yellow", YearOfStudyId = 1 },
            new Class { Id = 4, Name = "2 Red", YearOfStudyId = 2 },
            new Class { Id = 5, Name = "2 Blue", YearOfStudyId = 2 },
            new Class { Id = 6, Name = "2 Yellow", YearOfStudyId = 2 },
            new Class { Id = 7, Name = "3 Red", YearOfStudyId = 3 },
            new Class { Id = 8, Name = "3 Blue", YearOfStudyId = 3 },
            new Class { Id = 9, Name = "3 Yellow", YearOfStudyId = 3 },
            new Class { Id = 10, Name = "4 Red", YearOfStudyId = 4 },
            new Class { Id = 11, Name = "4 Blue", YearOfStudyId = 4 },
            new Class { Id = 12, Name = "4 Yellow", YearOfStudyId = 4 }
        );

        // Seed Competitions
        modelBuilder.Entity<Competition>().HasData(
            new Competition { Id = 1, Name = "Physics Olympiad" },
            new Competition { Id = 2, Name = "Chemistry Challenge" },
            new Competition { Id = 3, Name = "Biology Competition" },
            new Competition { Id = 4, Name = "Mathematics Tournament" }
        );

        // Seed Associations
        modelBuilder.Entity<Association>().HasData(
            new Association { Id = 1, Name = "Environment Club" },
            new Association { Id = 2, Name = "Science Club" },
            new Association { Id = 3, Name = "Math Club" },
            new Association { Id = 4, Name = "Robotics Club" },
            new Association { Id = 5, Name = "Innovation Club" }
        );

        // Seed Students
        var studentId = 1;
        var students = new List<Student>();

        // Form 1 Students
        // 1 Red
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Adam Smith", YearOfStudyId = 1, ClassId = 1 },
            new Student { Id = studentId++, Name = "Beth Johnson", YearOfStudyId = 1, ClassId = 1 },
            new Student { Id = studentId++, Name = "Charlie Brown", YearOfStudyId = 1, ClassId = 1 },
            new Student { Id = studentId++, Name = "Diana Ross", YearOfStudyId = 1, ClassId = 1 }
        });

        // 1 Blue
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Edward Lee", YearOfStudyId = 1, ClassId = 2 },
            new Student { Id = studentId++, Name = "Fiona Wilson", YearOfStudyId = 1, ClassId = 2 },
            new Student { Id = studentId++, Name = "George Chen", YearOfStudyId = 1, ClassId = 2 },
            new Student { Id = studentId++, Name = "Hannah Liu", YearOfStudyId = 1, ClassId = 2 }
        });

        // 1 Yellow
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Ian Foster", YearOfStudyId = 1, ClassId = 3 },
            new Student { Id = studentId++, Name = "Julia Zhang", YearOfStudyId = 1, ClassId = 3 },
            new Student { Id = studentId++, Name = "Kevin Patel", YearOfStudyId = 1, ClassId = 3 },
            new Student { Id = studentId++, Name = "Lucy Wang", YearOfStudyId = 1, ClassId = 3 }
        });

        // Form 2 Students
        // 2 Red
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Michael Kim", YearOfStudyId = 2, ClassId = 4 },
            new Student { Id = studentId++, Name = "Nancy Chen", YearOfStudyId = 2, ClassId = 4 },
            new Student { Id = studentId++, Name = "Oliver Tan", YearOfStudyId = 2, ClassId = 4 },
            new Student { Id = studentId++, Name = "Patricia Lee", YearOfStudyId = 2, ClassId = 4 }
        });

        // 2 Blue
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Quincy Adams", YearOfStudyId = 2, ClassId = 5 },
            new Student { Id = studentId++, Name = "Rachel Green", YearOfStudyId = 2, ClassId = 5 },
            new Student { Id = studentId++, Name = "Samuel Liu", YearOfStudyId = 2, ClassId = 5 },
            new Student { Id = studentId++, Name = "Tracy Wong", YearOfStudyId = 2, ClassId = 5 }
        });

        // 2 Yellow
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Uma Patel", YearOfStudyId = 2, ClassId = 6 },
            new Student { Id = studentId++, Name = "Victor Zhang", YearOfStudyId = 2, ClassId = 6 },
            new Student { Id = studentId++, Name = "Wendy Davis", YearOfStudyId = 2, ClassId = 6 },
            new Student { Id = studentId++, Name = "Xavier Chen", YearOfStudyId = 2, ClassId = 6 }
        });

        // Form 3 Students
        // 3 Red
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Yolanda Kim", YearOfStudyId = 3, ClassId = 7 },
            new Student { Id = studentId++, Name = "Zack Miller", YearOfStudyId = 3, ClassId = 7 },
            new Student { Id = studentId++, Name = "Alice Wang", YearOfStudyId = 3, ClassId = 7 },
            new Student { Id = studentId++, Name = "Bob Taylor", YearOfStudyId = 3, ClassId = 7 }
        });

        // 3 Blue
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Carol Lee", YearOfStudyId = 3, ClassId = 8 },
            new Student { Id = studentId++, Name = "David Chen", YearOfStudyId = 3, ClassId = 8 },
            new Student { Id = studentId++, Name = "Emily Liu", YearOfStudyId = 3, ClassId = 8 },
            new Student { Id = studentId++, Name = "Frank Zhang", YearOfStudyId = 3, ClassId = 8 }
        });

        // 3 Yellow
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Grace Park", YearOfStudyId = 3, ClassId = 9 },
            new Student { Id = studentId++, Name = "Henry Wu", YearOfStudyId = 3, ClassId = 9 },
            new Student { Id = studentId++, Name = "Iris Chen", YearOfStudyId = 3, ClassId = 9 },
            new Student { Id = studentId++, Name = "Jack Wong", YearOfStudyId = 3, ClassId = 9 }
        });

        // Form 4 Students
        // 4 Red
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Kelly Tan", YearOfStudyId = 4, ClassId = 10 },
            new Student { Id = studentId++, Name = "Leo Martinez", YearOfStudyId = 4, ClassId = 10 },
            new Student { Id = studentId++, Name = "Maria Garcia", YearOfStudyId = 4, ClassId = 10 },
            new Student { Id = studentId++, Name = "Nathan Lee", YearOfStudyId = 4, ClassId = 10 }
        });

        // 4 Blue
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Olivia Wilson", YearOfStudyId = 4, ClassId = 11 },
            new Student { Id = studentId++, Name = "Peter Zhang", YearOfStudyId = 4, ClassId = 11 },
            new Student { Id = studentId++, Name = "Quinn Chen", YearOfStudyId = 4, ClassId = 11 },
            new Student { Id = studentId++, Name = "Rosa Kim", YearOfStudyId = 4, ClassId = 11 }
        });

        // 4 Yellow
        students.AddRange(new[] {
            new Student { Id = studentId++, Name = "Steve Wang", YearOfStudyId = 4, ClassId = 12 },
            new Student { Id = studentId++, Name = "Tina Liu", YearOfStudyId = 4, ClassId = 12 },
            new Student { Id = studentId++, Name = "Ulysses Park", YearOfStudyId = 4, ClassId = 12 },
            new Student { Id = studentId++, Name = "Victoria Chen", YearOfStudyId = 4, ClassId = 12 }
        });

        modelBuilder.Entity<Student>().HasData(students);
    }
}
