using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebshopAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenamedUsernameToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Username");
        }
    }
}
