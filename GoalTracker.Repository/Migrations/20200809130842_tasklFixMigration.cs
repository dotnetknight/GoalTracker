using Microsoft.EntityFrameworkCore.Migrations;

namespace GoalTracker.Repository.Migrations
{
    public partial class tasklFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TasklToTime",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "TaskToTime",
                table: "Task",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskToTime",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "TasklToTime",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
