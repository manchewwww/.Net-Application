using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "currency_code",
                table: "currencies",
                newName: "code");

            migrationBuilder.RenameIndex(
                name: "IX_currencies_currency_code",
                table: "currencies",
                newName: "IX_currencies_code");

            migrationBuilder.RenameColumn(
                name: "country_code",
                table: "countries",
                newName: "code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code",
                table: "currencies",
                newName: "currency_code");

            migrationBuilder.RenameIndex(
                name: "IX_currencies_code",
                table: "currencies",
                newName: "IX_currencies_currency_code");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "countries",
                newName: "country_code");
        }
    }
}
