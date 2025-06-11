namespace Kris.Models;

public class FilterRegistrationModel
{
    public int? YearOfStudyId { get; set; }
    public int? ClassId { get; set; }
    public string? StudentName { get; set; }
    
    public bool HasFilters => YearOfStudyId.HasValue || ClassId.HasValue || !string.IsNullOrWhiteSpace(StudentName);
    
    public void Clear()
    {
        YearOfStudyId = null;
        ClassId = null;
        StudentName = null;
    }
}
