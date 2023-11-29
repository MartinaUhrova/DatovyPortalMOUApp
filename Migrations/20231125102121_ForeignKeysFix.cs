using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatovyPortalApp.Migrations
{
    public partial class ForeignKeysFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Statistics_StatisticsId",
                table: "Statistics",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_IndicatorId",
                table: "Statistics",
                column: "IndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_RegionId",
                table: "Statistics",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_PeriodId",
                table: "Statistics",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_StatisticsCodeList_StatisticsId",
                table: "Statistics",
                column: "StatisticsId",
                principalTable: "StatisticsCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_IndicatorCodeList_IndicatorId",
                table: "Statistics",
                column: "IndicatorId",
                principalTable: "IndicatorCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_RegionCodeList_RegionId",
                table: "Statistics",
                column: "RegionId",
                principalTable: "RegionCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_PeriodCodeList_PeriodId",
                table: "Statistics",
                column: "PeriodId",
                principalTable: "PeriodCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
