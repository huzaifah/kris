using System.ComponentModel.DataAnnotations;

namespace Kris.Models;

public class EditRegistrationModel
{
    public int RegistrationId { get; set; }

    [Required(ErrorMessage = "Sila pilih pertandingan")]
    [Range(1, int.MaxValue, ErrorMessage = "Sila pilih pertandingan yang sah")]
    public int CompetitionId { get; set; }

    public int OriginalCompetitionId { get; set; }

    // Read-only display properties
    public string StudentName { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string YearName { get; set; } = string.Empty;
    public string AssociationName { get; set; } = string.Empty;
    public string CurrentCompetitionName { get; set; } = string.Empty;

    // Change tracking
    public bool HasChanges => CompetitionId != OriginalCompetitionId;

    // Helper method to create from Registration entity
    public static EditRegistrationModel FromRegistration(Registration registration)
    {
        return new EditRegistrationModel
        {
            RegistrationId = registration.Id,
            CompetitionId = registration.CompetitionId,
            OriginalCompetitionId = registration.CompetitionId,
            StudentName = registration.Student?.Name ?? "",
            ClassName = registration.Student?.Class?.Name ?? "",
            YearName = registration.Student?.YearOfStudy?.Name ?? "",
            AssociationName = registration.Association?.Name ?? "",
            CurrentCompetitionName = registration.Competition?.Name ?? ""
        };
    }
}
