using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailo.Migrations
{
    /// <inheritdoc />
    public partial class edits1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[OrderPrice] + ' ' + [DeliveryFee]",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[OrderPrice] + ' ' + [DeliveryFee]");
        }
    }
}
