using System.ComponentModel.DataAnnotations;
using Kris.Models;

namespace Kris.Tests;

public class RegistrationModelTests
{
    [Fact]
    public void RegistrationModel_ValidModel_PassesValidation()
    {
        // Arrange
        var model = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 1,
            AssociationId = 1,
            CompetitionId = 1
        };

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(results);
    }

    [Fact]
    public void RegistrationModel_MissingStudentId_FailsValidation()
    {
        // Arrange
        var model = new RegistrationModel
        {
            YearOfStudyId = 1,
            ClassId = 1,
            StudentId = 0,
            AssociationId = 1,
            CompetitionId = 1
        };

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(results, r => r.MemberNames.Contains(nameof(RegistrationModel.StudentId)));
    }

    [Theory]
    [InlineData(0, 1, 1, 1, 1, false)] // Missing YearOfStudyId
    [InlineData(1, 0, 1, 1, 1, false)] // Missing ClassId
    [InlineData(1, 1, 0, 1, 1, false)] // Missing StudentId
    [InlineData(1, 1, 1, 0, 1, false)] // Missing AssociationId
    [InlineData(1, 1, 1, 1, 0, false)] // Missing CompetitionId
    [InlineData(0, 0, 0, 0, 0, false)] // All missing
    [InlineData(1, 1, 1, 1, 1, true)]  // All valid
    public void RegistrationModel_ValidationTest(int yearOfStudyId, int classId, int studentId, int associationId, int competitionId, bool expectedValid)
    {
        // Arrange
        var model = new RegistrationModel
        {
            YearOfStudyId = yearOfStudyId,
            ClassId = classId,
            StudentId = studentId,
            AssociationId = associationId,
            CompetitionId = competitionId
        };

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        // Assert
        Assert.Equal(expectedValid, isValid);
    }

    [Fact]
    public void RegistrationModel_AllPropertiesSet_ReturnsCorrectValues()
    {
        // Arrange
        var yearOfStudyId = 2;
        var classId = 4;
        var studentId = 5;
        var associationId = 3;
        var competitionId = 2;

        // Act
        var model = new RegistrationModel
        {
            YearOfStudyId = yearOfStudyId,
            ClassId = classId,
            StudentId = studentId,
            AssociationId = associationId,
            CompetitionId = competitionId
        };

        // Assert
        Assert.Equal(yearOfStudyId, model.YearOfStudyId);
        Assert.Equal(classId, model.ClassId);
        Assert.Equal(studentId, model.StudentId);
        Assert.Equal(associationId, model.AssociationId);
        Assert.Equal(competitionId, model.CompetitionId);
    }
}
