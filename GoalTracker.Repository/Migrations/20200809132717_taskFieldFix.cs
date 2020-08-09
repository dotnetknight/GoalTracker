using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoalTracker.Repository.Migrations
{
    public partial class taskFieldFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskFromTime",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskToTime",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "TaskEndTime",
                table: "Task",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskStartTime",
                table: "Task",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskEndTime",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskStartTime",
                table: "Task");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TaskFromTime",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskToTime",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
