using Microsoft.EntityFrameworkCore.Migrations;

namespace GoalTracker.Repository.Migrations
{
    public partial class addedOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "DailyTasks",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "DailyTasks");
        }
    }
}
