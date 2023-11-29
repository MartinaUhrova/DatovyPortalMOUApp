using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatovyPortalApp.Migrations
{
    public partial class ErrorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaidumId",
                table: "Statistics",
                newName: "StadiumId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IndicatorCodeList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdSet",
                table: "IndicatorCodeList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "IndicatorCodeList");

            migrationBuilder.DropColumn(
                name: "IdSet",
                table: "IndicatorCodeList");

            migrationBuilder.RenameColumn(
                name: "StadiumId",
                table: "Statistics",
                newName: "StaidumId");
        }
    }
}
