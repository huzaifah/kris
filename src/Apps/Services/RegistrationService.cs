using Kris.Models;
using Microsoft.EntityFrameworkCore;
using Kris.Data;

namespace Kris.Services;

public class RegistrationService
{
    private readonly AppDbContext _db;
    public RegistrationService(AppDbContext db) => _db = db;

    public async Task<List<YearOfStudy>> GetYearsAsync() => 
        await _db.YearsOfStudy.ToListAsync();

    public async Task<List<Class>> GetClassesByYearAsync(int yearId) => 
        await _db.Classes.Where(c => c.YearOfStudyId == yearId).ToListAsync();

    public async Task<List<Student>> GetStudentsByClassAsync(int yearId, int classId) =>
        await _db.Students
            .Where(s => s.YearOfStudyId == yearId && s.ClassId == classId)
            .OrderBy(s => s.Name)
            .ToListAsync();

    public async Task<List<Association>> GetAssociationsAsync() =>
        await _db.Associations.OrderBy(a => a.Name).ToListAsync();

    public async Task<List<Competition>> GetCompetitionsAsync() => 
        await _db.Competitions.ToListAsync();

    public async Task<Registration> RegisterAsync(RegistrationModel model)
    {
        var student = await _db.Students
            .Include(s => s.YearOfStudy)
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == model.StudentId)
            ?? throw new InvalidOperationException("Student not found");

        var association = await _db.Associations.FindAsync(model.AssociationId)
            ?? throw new InvalidOperationException("Association not found");

        var competition = await _db.Competitions.FindAsync(model.CompetitionId)
            ?? throw new InvalidOperationException("Competition not found");

        var registration = new Registration
        {
            StudentId = model.StudentId,
            Student = student,
            AssociationId = model.AssociationId,
            Association = association,
            CompetitionId = model.CompetitionId,
            Competition = competition,
            RegistrationDate = DateTime.UtcNow
        };

        _db.Registrations.Add(registration);
        await _db.SaveChangesAsync();
        
        return registration;
    }

    public async Task<Dictionary<string, Dictionary<string, List<Registration>>>> GetRegistrationsGroupedAsync()
    {
        var registrations = await _db.Registrations
            .Include(r => r.Student)
            .ThenInclude(s => s!.YearOfStudy)
            .Include(r => r.Student)
            .ThenInclude(s => s!.Class)
            .Include(r => r.Association)
            .Include(r => r.Competition)
            .OrderBy(r => r.Student!.YearOfStudy!.Name)
            .ThenBy(r => r.Student!.Class!.Name)
            .ThenBy(r => r.Student!.Name)
            .ToListAsync();

        return registrations
            .GroupBy(r => r.Student?.YearOfStudy?.Name ?? "Unknown")
            .ToDictionary(
                year => year.Key,
                year => year.GroupBy(r => r.Student?.Class?.Name ?? "Unknown")
                    .ToDictionary(
                        cls => cls.Key,
                        cls => cls.ToList()
                    )
            );
    }
}
