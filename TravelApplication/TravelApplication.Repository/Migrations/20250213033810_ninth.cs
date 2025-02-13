using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApplication.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ninth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageActivities_TravelPackages_TravelPackageId",
                table: "TravelPackageActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageAttractions_TravelPackages_TravelPackageId",
                table: "TravelPackageAttractions");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageMeals_TravelPackages_TravelPackageId",
                table: "TravelPackageMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageTransports_TravelPackages_TravelPackageId",
                table: "TravelPackageTransports");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "TravelPackageTransports");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "TravelPackageMeals");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "TravelPackageAttractions");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "TravelPackageActivities");

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageTransports",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageMeals",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageAttractions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageActivities",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_DestinationId1",
                table: "TravelPackages",
                column: "DestinationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageActivities_TravelPackages_TravelPackageId",
                table: "TravelPackageActivities",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageAttractions_TravelPackages_TravelPackageId",
                table: "TravelPackageAttractions",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageMeals_TravelPackages_TravelPackageId",
                table: "TravelPackageMeals",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId1",
                table: "TravelPackages",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageTransports_TravelPackages_TravelPackageId",
                table: "TravelPackageTransports",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageActivities_TravelPackages_TravelPackageId",
                table: "TravelPackageActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageAttractions_TravelPackages_TravelPackageId",
                table: "TravelPackageAttractions");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageMeals_TravelPackages_TravelPackageId",
                table: "TravelPackageMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId1",
                table: "TravelPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageTransports_TravelPackages_TravelPackageId",
                table: "TravelPackageTransports");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_DestinationId1",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "TravelPackages");

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageTransports",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "TravelPackageTransports",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageMeals",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "TravelPackageMeals",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageAttractions",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "TravelPackageAttractions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelPackageId",
                table: "TravelPackageActivities",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "TravelPackageActivities",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageActivities_TravelPackages_TravelPackageId",
                table: "TravelPackageActivities",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageAttractions_TravelPackages_TravelPackageId",
                table: "TravelPackageAttractions",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageMeals_TravelPackages_TravelPackageId",
                table: "TravelPackageMeals",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId",
                table: "TravelPackages",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageTransports_TravelPackages_TravelPackageId",
                table: "TravelPackageTransports",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id");
        }
    }
}
