using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddNewGoalTodB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignmentDate", "Deadline" },
                values: new object[] { new DateTime(2024, 2, 25, 22, 49, 51, 296, DateTimeKind.Local).AddTicks(4075), new DateTime(2024, 2, 25, 22, 49, 51, 296, DateTimeKind.Local).AddTicks(4119) });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "AssignmentDate", "Deadline", "IsCompleted", "Name", "Record", "StudentId", "Target" },
                values: new object[] { 4, new DateTime(2024, 2, 25, 22, 49, 51, 296, DateTimeKind.Local).AddTicks(4123), new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "writing", 0, 2, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignmentDate", "Deadline" },
                values: new object[] { new DateTime(2024, 2, 25, 22, 8, 31, 447, DateTimeKind.Local).AddTicks(5422), new DateTime(2024, 2, 25, 22, 8, 31, 447, DateTimeKind.Local).AddTicks(5475) });
        }
    }
}
