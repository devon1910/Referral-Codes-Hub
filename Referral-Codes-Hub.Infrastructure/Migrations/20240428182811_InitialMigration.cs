using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Referral_Codes_Hub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReferralCodes",
                columns: table => new
                {
                    RefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferralLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfUsersReferred = table.Column<int>(type: "int", nullable: false),
                    ReferredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralCodes", x => x.RefId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferralCodes");
        }
    }
}
