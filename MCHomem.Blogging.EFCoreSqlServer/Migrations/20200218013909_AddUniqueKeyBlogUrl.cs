using Microsoft.EntityFrameworkCore.Migrations;

namespace MCHomem.Blogging.EFCoreSqlServer.Migrations
{
    public partial class AddUniqueKeyBlogUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Blog_Url",
                table: "Blog",
                column: "Url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Blog_Url",
                table: "Blog");
        }
    }
}
