using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCI.CleanEgypt.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName],[ConcurrencyStamp]) VALUES (NEWID(), 'Admin', 'ADMIN', NEWID())");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName],[ConcurrencyStamp]) VALUES (NEWID(), 'User', 'USER', NEWID())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles] WHERE [Name] IN ('Admin', 'Doctor', 'User')");
        }
    }
}