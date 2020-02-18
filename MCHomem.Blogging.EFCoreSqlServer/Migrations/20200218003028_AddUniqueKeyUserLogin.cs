using Microsoft.EntityFrameworkCore.Migrations;

namespace MCHomem.Blogging.EFCoreSqlServer.Migrations
{
    public partial class AddUniqueKeyUserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                table: "User",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Login",
                table: "User");
        }
    }
}
