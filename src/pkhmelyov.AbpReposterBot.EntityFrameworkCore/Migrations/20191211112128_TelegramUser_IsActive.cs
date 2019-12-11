using Microsoft.EntityFrameworkCore.Migrations;

namespace pkhmelyov.AbpReposterBot.Migrations
{
    public partial class TelegramUser_IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TelegramUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TelegramUsers");
        }
    }
}
