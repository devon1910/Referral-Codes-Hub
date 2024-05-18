using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Referral_Codes_Hub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ReferralCodes",
                newName: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "ReferralCodes",
                newName: "UserId");
        }
    }
}
