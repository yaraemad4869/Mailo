using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailo.Migrations
{
    /// <inheritdoc />
    public partial class edits2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[FName] + ' ' + [LName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "[FName] + ' ' + [LName]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[FName] + ' ' + [LName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[FName] + ' ' + [LName]");
        }
    }
}
