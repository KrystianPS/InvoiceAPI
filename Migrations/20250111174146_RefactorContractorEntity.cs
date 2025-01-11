using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefactorContractorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyContractor");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Contractors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_CompanyId",
                table: "Contractors",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_Companies_CompanyId",
                table: "Contractors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_Companies_CompanyId",
                table: "Contractors");

            migrationBuilder.DropIndex(
                name: "IX_Contractors_CompanyId",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Contractors");

            migrationBuilder.CreateTable(
                name: "CompanyContractor",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    ContractorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContractor", x => new { x.CompaniesId, x.ContractorsId });
                    table.ForeignKey(
                        name: "FK_CompanyContractor_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContractor_Contractors_ContractorsId",
                        column: x => x.ContractorsId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContractor_ContractorsId",
                table: "CompanyContractor",
                column: "ContractorsId");
        }
    }
}
