using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kris.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegistrationEntityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRange",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "SchoolName",
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

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ClassId",
                table: "Registrations",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_YearOfStudyId",
                table: "Registrations",
                column: "YearOfStudyId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Registrations_YearOfStudyId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "YearOfStudyId",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "AssociationName",
                table: "Registrations",
                newName: "SchoolName");

            migrationBuilder.AddColumn<string>(
                name: "AgeRange",
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
        }
    }
}
