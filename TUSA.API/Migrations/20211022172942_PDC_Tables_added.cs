using Microsoft.EntityFrameworkCore.Migrations;

namespace TUSA.API.Migrations
{
    public partial class PDC_Tables_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pdc_gm_elements_master",
                columns: table => new
                {
                    masterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<int>(type: "int", nullable: true),
                    phase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    units = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceOrEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_gm_elements_master", x => x.masterId);
                });

            migrationBuilder.CreateTable(
                name: "pdc_gm_header",
                columns: table => new
                {
                    headerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    project_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    project_year = table.Column<int>(type: "int", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_project_cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    year_1_OnM_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    year_2_OnM_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    installed_capacity_dc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    installed_capacity_ac = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    year_1_yield = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    guaranteed_perf_ratio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    minimum_perf_ratio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    guaranteed_availability = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    cod = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_gm_header", x => x.headerId);
                });

            migrationBuilder.CreateTable(
                name: "pdc_gm_project_data",
                columns: table => new
                {
                    masterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    headerId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    share_in_Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    scope_commmentary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modeltype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    totalServiceHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_gm_project_data", x => x.masterId);
                });

            migrationBuilder.CreateTable(
                name: "pdc_gm_scopecategry",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryOrder = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_gm_scopecategry", x => x.categoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pdc_gm_elements_master");

            migrationBuilder.DropTable(
                name: "pdc_gm_header");

            migrationBuilder.DropTable(
                name: "pdc_gm_project_data");

            migrationBuilder.DropTable(
                name: "pdc_gm_scopecategry");
        }
    }
}
