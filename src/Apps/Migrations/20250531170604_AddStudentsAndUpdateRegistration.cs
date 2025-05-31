using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kris.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsAndUpdateRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Classes_ClassId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_YearsOfStudy_YearOfStudyId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_ClassId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "YearOfStudyId",
                table: "Registrations",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_YearOfStudyId",
                table: "Registrations",
                newName: "IX_Registrations_StudentId");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    YearOfStudyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_YearsOfStudy_YearOfStudyId",
                        column: x => x.YearOfStudyId,
                        principalTable: "YearsOfStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "Name", "YearOfStudyId" },
                values: new object[,]
                {
                    { 1, 1, "Adam Smith", 1 },
                    { 2, 1, "Beth Johnson", 1 },
                    { 3, 1, "Charlie Brown", 1 },
                    { 4, 2, "David Lee", 1 },
                    { 5, 2, "Emma Wilson", 1 },
                    { 6, 2, "Frank Chen", 1 },
                    { 7, 4, "Grace Kim", 2 },
                    { 8, 4, "Henry Tan", 2 },
                    { 9, 4, "Ivy Zhang", 2 },
                    { 10, 5, "Jack Wong", 2 },
                    { 11, 5, "Katie Davis", 2 },
                    { 12, 5, "Liam Miller", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_YearOfStudyId",
                table: "Students",
                column: "YearOfStudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Students_StudentId",
                table: "Registrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Students_StudentId",
                table: "Registrations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Registrations",
                newName: "YearOfStudyId");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_StudentId",
                table: "Registrations",
                newName: "IX_Registrations_YearOfStudyId");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ClassId",
                table: "Registrations",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Classes_ClassId",
                table: "Registrations",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_YearsOfStudy_YearOfStudyId",
                table: "Registrations",
                column: "YearOfStudyId",
                principalTable: "YearsOfStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
