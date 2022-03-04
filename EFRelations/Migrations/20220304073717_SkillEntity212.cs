using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFRelations.Migrations
{
    public partial class SkillEntity212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharacterId",
                table: "Skills",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CharacterId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Skills");
        }
    }
}
