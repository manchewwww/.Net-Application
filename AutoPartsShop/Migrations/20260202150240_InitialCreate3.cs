using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoPartsShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_part_supplier_links",
                table: "part_supplier_links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_part_fitments",
                table: "part_fitments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory",
                table: "inventory");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "part_supplier_links",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "part_fitments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "inventory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_part_supplier_links",
                table: "part_supplier_links",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_part_fitments",
                table: "part_fitments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory",
                table: "inventory",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_part_supplier_links_part_id_supplier_part_id",
                table: "part_supplier_links",
                columns: new[] { "part_id", "supplier_part_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_part_fitments_part_id_variant_id",
                table: "part_fitments",
                columns: new[] { "part_id", "variant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_part_id_warehouse_id",
                table: "inventory",
                columns: new[] { "part_id", "warehouse_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_part_supplier_links",
                table: "part_supplier_links");

            migrationBuilder.DropIndex(
                name: "IX_part_supplier_links_part_id_supplier_part_id",
                table: "part_supplier_links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_part_fitments",
                table: "part_fitments");

            migrationBuilder.DropIndex(
                name: "IX_part_fitments_part_id_variant_id",
                table: "part_fitments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory",
                table: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_inventory_part_id_warehouse_id",
                table: "inventory");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "part_supplier_links",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "part_fitments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "inventory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_part_supplier_links",
                table: "part_supplier_links",
                columns: new[] { "part_id", "supplier_part_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_part_fitments",
                table: "part_fitments",
                columns: new[] { "part_id", "variant_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory",
                table: "inventory",
                columns: new[] { "part_id", "warehouse_id" });
        }
    }
}
