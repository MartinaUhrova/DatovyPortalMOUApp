using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatovyPortalApp.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.CreateIndex(
                name: "IX_Statistics_DiagnosisId",
                table: "Statistics",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_StadiumId",
                table: "Statistics",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_SetId",
                table: "Statistics",
                column: "SetId");

                                    

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_DiagnosisCodeList_DiagnosisId",
                table: "Statistics",
                column: "DiagnosisId",
                principalTable: "DiagnosisCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_StadiumCodeList_StadiumId",
                table: "Statistics",
                column: "StadiumId",
                principalTable: "StadiumCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_SetCodeList_SetId",
                table: "Statistics",
                column: "SetId",
                principalTable: "SetCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_DiagnosisCodeList_DiagnosisId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_StadiumCodeList_StadiumId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_DiagnosisId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_StadiumId",
                table: "Statistics");

            migrationBuilder.AddColumn<int>(
                name: "DiagnosisCodeListId",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaidumId",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_DiagnosisCodeListId",
                table: "Statistics",
                column: "DiagnosisCodeListId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_StaidumId",
                table: "Statistics",
                column: "StaidumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_DiagnosisCodeList_DiagnosisCodeListId",
                table: "Statistics",
                column: "DiagnosisCodeListId",
                principalTable: "DiagnosisCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_StadiumCodeList_StaidumId",
                table: "Statistics",
                column: "StaidumId",
                principalTable: "StadiumCodeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
