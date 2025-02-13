using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApplication.Repository.Migrations
{
    /// <inheritdoc />
    public partial class idk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId1",
                table: "TravelPackages");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_DestinationId1",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "TravelPackages");

            migrationBuilder.AlterColumn<Guid>(
                name: "DestinationId",
                table: "TravelPackages",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId",
                table: "TravelPackages",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages");

            migrationBuilder.AlterColumn<string>(
                name: "DestinationId",
                table: "TravelPackages",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId1",
                table: "TravelPackages",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_DestinationId1",
                table: "TravelPackages",
                column: "DestinationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId1",
                table: "TravelPackages",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id");
        }
    }
}
