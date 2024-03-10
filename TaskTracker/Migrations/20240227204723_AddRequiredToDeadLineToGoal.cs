using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddRequiredToDeadLineToGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Goals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignmentDate", "Deadline" },
                values: new object[] { new DateTime(2024, 2, 27, 21, 47, 23, 140, DateTimeKind.Local).AddTicks(9925), new DateTime(2024, 2, 27, 21, 47, 23, 140, DateTimeKind.Local).AddTicks(9973) });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignmentDate",
                value: new DateTime(2024, 2, 27, 21, 47, 23, 140, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Students");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Goals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignmentDate", "Deadline" },
                values: new object[] { new DateTime(2024, 2, 25, 22, 49, 51, 296, DateTimeKind.Local).AddTicks(4075), new DateTime(2024, 2, 25, 22, 49, 51, 296, DateTimeKind.Local).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignmentDate",
                value: new DateTime(2024, 2, 25, 22, 49, 51, 296, DateTimeKind.Local).AddTicks(4123));
        }
    }
}
