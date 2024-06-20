using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCI.CleanEgypt.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditPinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Pins");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pins");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Pins",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Pins",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Pins",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Pins",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfWaste",
                table: "Pins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Pins");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Pins");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Pins");

            migrationBuilder.DropColumn(
                name: "TypeOfWaste",
                table: "Pins");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Pins",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Pins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pins",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
