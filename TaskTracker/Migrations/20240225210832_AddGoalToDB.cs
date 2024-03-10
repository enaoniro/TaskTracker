using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddGoalToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    Record = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "AssignmentDate", "Deadline", "IsCompleted", "Name", "Record", "StudentId", "Target" },
                values: new object[] { 3, new DateTime(2024, 2, 25, 22, 8, 31, 447, DateTimeKind.Local).AddTicks(5422), new DateTime(2024, 2, 25, 22, 8, 31, 447, DateTimeKind.Local).AddTicks(5475), false, "reading", 0, 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_StudentId",
                table: "Goals",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
