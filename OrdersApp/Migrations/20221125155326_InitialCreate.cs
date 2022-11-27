using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sku_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sku_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<int>(name: "customer_id", type: "int", nullable: false),
                    orderdate = table.Column<DateTime>(name: "order_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_customers_customer_id",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skucategoryid = table.Column<int>(name: "sku_category_id", type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_skus", x => x.id);
                    table.ForeignKey(
                        name: "fk_skus_sku_categories_sku_category_id",
                        column: x => x.skucategoryid,
                        principalTable: "sku_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_skus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skuid = table.Column<int>(name: "sku_id", type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    sum = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_skus", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_skus_orders_order_id",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_skus_skus_sku_id",
                        column: x => x.skuid,
                        principalTable: "skus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_skus_order_id",
                table: "order_skus",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_skus_sku_id",
                table: "order_skus",
                column: "sku_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_customer_id",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_skus_sku_category_id",
                table: "skus",
                column: "sku_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_skus");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "skus");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "sku_categories");
        }
    }
}
