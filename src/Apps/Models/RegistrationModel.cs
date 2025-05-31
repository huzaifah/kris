using System.ComponentModel.DataAnnotations;

namespace Kris.Models;

public class RegistrationModel
{
    [Required(ErrorMessage = "Please select a year of study")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid year of study")]
    public int YearOfStudyId { get; set; }

    [Required(ErrorMessage = "Please select a class")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid class")]
    public int ClassId { get; set; }

    [Required(ErrorMessage = "Please select a student")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid student")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Please select an association")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid association")]
    public int AssociationId { get; set; }

    [Required(ErrorMessage = "Please select a competition")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid competition")]
    public int CompetitionId { get; set; }
}
