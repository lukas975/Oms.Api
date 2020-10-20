using Microsoft.EntityFrameworkCore.Migrations;

namespace Oms.Api.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "oms");

            migrationBuilder.CreateTable(
                name: "OrderDatails",
                schema: "oms",
                columns: table => new
                {
                    FactoryId = table.Column<string>(nullable: false),
                    FactoryName = table.Column<string>(nullable: true),
                    FactoryAddress = table.Column<string>(nullable: true),
                    FactoryCountry = table.Column<string>(nullable: false),
                    ProductionLineId = table.Column<string>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    ProductDescription = table.Column<string>(nullable: false),
                    PoNumber = table.Column<string>(nullable: true),
                    ExpectedStartDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDatails", x => x.FactoryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                schema: "oms",
                columns: table => new
                {
                    Gtin = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false),
                    Quantity = table.Column<long>(nullable: false),
                    SerialNumberType = table.Column<string>(nullable: false),
                    SerialNumbers = table.Column<string>(nullable: false),
                    TemplateId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Gtin);
                });

            migrationBuilder.CreateTable(
                name: "Cms",
                schema: "oms",
                columns: table => new
                {
                    CmsId = table.Column<string>(nullable: false),
                    Products = table.Column<string>(nullable: false),
                    FactoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms", x => x.CmsId);
                    table.ForeignKey(
                        name: "FK_Cms_OrderDatails_FactoryId",
                        column: x => x.FactoryId,
                        principalSchema: "oms",
                        principalTable: "OrderDatails",
                        principalColumn: "FactoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cms_FactoryId",
                schema: "oms",
                table: "Cms",
                column: "FactoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cms",
                schema: "oms");

            migrationBuilder.DropTable(
                name: "OrderProduct",
                schema: "oms");

            migrationBuilder.DropTable(
                name: "OrderDatails",
                schema: "oms");
        }
    }
}
