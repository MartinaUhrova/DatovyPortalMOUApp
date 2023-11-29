using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatovyPortalApp.Migrations
{
    public partial class AllTablesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnosisCodeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisCodeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorCodeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorCodeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodCodeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodCodeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionCodeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionCodeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StadiumCodeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadiumCodeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetId = table.Column<int>(type: "int", nullable: false),
                    IndicatorId = table.Column<int>(type: "int", nullable: false),
                    DiagnosisId = table.Column<int>(type: "int", nullable: false),
                    StaidumId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    StatisticsId = table.Column<int>(type: "int", nullable: false),
                    SampleSize = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    LowerLimit = table.Column<double>(type: "float", nullable: false),
                    UpperLimit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatisticsCodeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsCodeList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosisCodeList");

            migrationBuilder.DropTable(
                name: "IndicatorCodeList");

            migrationBuilder.DropTable(
                name: "PeriodCodeList");

            migrationBuilder.DropTable(
                name: "RegionCodeList");

            migrationBuilder.DropTable(
                name: "StadiumCodeList");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "StatisticsCodeList");
        }
    }
}
