using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kris.Migrations
{
    /// <inheritdoc />
    public partial class AddAssociations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssociationName",
                table: "Registrations");

            migrationBuilder.AddColumn<int>(
                name: "AssociationId",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Associations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Environment Club" },
                    { 2, "Science Club" },
                    { 3, "Math Club" },
                    { 4, "Robotics Club" },
                    { 5, "Innovation Club" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AssociationId",
                table: "Registrations",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Associations_AssociationId",
                table: "Registrations",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Associations_AssociationId",
                table: "Registrations");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_AssociationId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "AssociationId",
                table: "Registrations");

            migrationBuilder.AddColumn<string>(
                name: "AssociationName",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
