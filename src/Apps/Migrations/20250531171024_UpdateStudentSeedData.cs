using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kris.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClassId", "Name" },
                values: new object[] { 1, "Diana Ross" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Edward Lee");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Fiona Wilson");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 2, "George Chen", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 2, "Hannah Liu", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 3, "Ian Foster", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 3, "Julia Zhang", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 3, "Kevin Patel", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 3, "Lucy Wang", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "Name", "YearOfStudyId" },
                values: new object[,]
                {
                    { 13, 4, "Michael Kim", 2 },
                    { 14, 4, "Nancy Chen", 2 },
                    { 15, 4, "Oliver Tan", 2 },
                    { 16, 4, "Patricia Lee", 2 },
                    { 17, 5, "Quincy Adams", 2 },
                    { 18, 5, "Rachel Green", 2 },
                    { 19, 5, "Samuel Liu", 2 },
                    { 20, 5, "Tracy Wong", 2 },
                    { 21, 6, "Uma Patel", 2 },
                    { 22, 6, "Victor Zhang", 2 },
                    { 23, 6, "Wendy Davis", 2 },
                    { 24, 6, "Xavier Chen", 2 },
                    { 25, 7, "Yolanda Kim", 3 },
                    { 26, 7, "Zack Miller", 3 },
                    { 27, 7, "Alice Wang", 3 },
                    { 28, 7, "Bob Taylor", 3 },
                    { 29, 8, "Carol Lee", 3 },
                    { 30, 8, "David Chen", 3 },
                    { 31, 8, "Emily Liu", 3 },
                    { 32, 8, "Frank Zhang", 3 },
                    { 33, 9, "Grace Park", 3 },
                    { 34, 9, "Henry Wu", 3 },
                    { 35, 9, "Iris Chen", 3 },
                    { 36, 9, "Jack Wong", 3 },
                    { 37, 10, "Kelly Tan", 4 },
                    { 38, 10, "Leo Martinez", 4 },
                    { 39, 10, "Maria Garcia", 4 },
                    { 40, 10, "Nathan Lee", 4 },
                    { 41, 11, "Olivia Wilson", 4 },
                    { 42, 11, "Peter Zhang", 4 },
                    { 43, 11, "Quinn Chen", 4 },
                    { 44, 11, "Rosa Kim", 4 },
                    { 45, 12, "Steve Wang", 4 },
                    { 46, 12, "Tina Liu", 4 },
                    { 47, 12, "Ulysses Park", 4 },
                    { 48, 12, "Victoria Chen", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClassId", "Name" },
                values: new object[] { 2, "David Lee" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Emma Wilson");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Frank Chen");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 4, "Grace Kim", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 4, "Henry Tan", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 4, "Ivy Zhang", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 5, "Jack Wong", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 5, "Katie Davis", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ClassId", "Name", "YearOfStudyId" },
                values: new object[] { 5, "Liam Miller", 2 });
        }
    }
}
