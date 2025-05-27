using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordBox.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToDataRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Records");
        }
    }
}
