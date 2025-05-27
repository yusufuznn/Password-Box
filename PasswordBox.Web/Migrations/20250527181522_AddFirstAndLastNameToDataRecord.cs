using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordBox.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstAndLastNameToDataRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Records");
        }
    }
}
