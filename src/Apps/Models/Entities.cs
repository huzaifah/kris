namespace Kris.Models;

public class YearOfStudy
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Class> Classes { get; set; } = new List<Class>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
}

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int YearOfStudyId { get; set; }
    public YearOfStudy? YearOfStudy { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int YearOfStudyId { get; set; }
    public YearOfStudy? YearOfStudy { get; set; }
    public int ClassId { get; set; }
    public Class? Class { get; set; }
    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}

public class Association
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}

public class Registration
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int AssociationId { get; set; }
    public Association? Association { get; set; }
    public int CompetitionId { get; set; }
    public Competition? Competition { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}
