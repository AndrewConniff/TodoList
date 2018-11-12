using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class FixModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Task",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskTitle",
                table: "Tasks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "Tasks",
                newName: "Completed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tasks",
                newName: "TaskTitle");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "Tasks",
                newName: "IsComplete");

            migrationBuilder.AddColumn<string>(
                name: "Task",
                table: "Tasks",
                nullable: true);
        }
    }
}
