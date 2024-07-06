using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSB_.net_task.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitiesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamMemberId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeamMemberId",
                table: "Tasks",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMemberId",
                table: "Tasks",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMemberId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TeamMemberId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "Tasks");
        }
    }
}
