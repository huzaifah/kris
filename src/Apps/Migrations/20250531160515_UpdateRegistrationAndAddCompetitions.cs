using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kris.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegistrationAndAddCompetitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "YearOfStudyId",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "RegisteredAt",
                table: "Registrations",
                newName: "SchoolName");

            migrationBuilder.RenameColumn(
                name: "AssociationName",
                table: "Registrations",
                newName: "RegistrationDate");

            migrationBuilder.AddColumn<string>(
                name: "AgeRange",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Competitions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Physics Olympiad" },
                    { 2, "Chemistry Challenge" },
                    { 3, "Biology Competition" },
                    { 4, "Mathematics Tournament" }
                });

            migrationBuilder.InsertData(
                table: "YearsOfStudy",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Form 1" },
                    { 2, "Form 2" },
                    { 3, "Form 3" },
                    { 4, "Form 4" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name", "YearOfStudyId" },
                values: new object[,]
                {
                    { 1, "1 Red", 1 },
                    { 2, "1 Blue", 1 },
                    { 3, "1 Yellow", 1 },
                    { 4, "2 Red", 2 },
                    { 5, "2 Blue", 2 },
                    { 6, "2 Yellow", 2 },
                    { 7, "3 Red", 3 },
                    { 8, "3 Blue", 3 },
                    { 9, "3 Yellow", 3 },
                    { 10, "4 Red", 4 },
                    { 11, "4 Blue", 4 },
                    { 12, "4 Yellow", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CompetitionId",
                table: "Registrations",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Competitions_CompetitionId",
                table: "Registrations",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Competitions_CompetitionId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_CompetitionId",
                table: "Registrations");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "YearsOfStudy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "YearsOfStudy",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YearsOfStudy",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "YearsOfStudy",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "AgeRange",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "SchoolName",
                table: "Registrations",
                newName: "RegisteredAt");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Registrations",
                newName: "AssociationName");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearOfStudyId",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
