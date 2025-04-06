using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalProducts.Infra.Migrations
{
    /// <inheritdoc />
    public partial class EditTypeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_TypeProductId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductId",
                table: "Products",
                column: "TypeProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_TypeProductId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductId",
                table: "Products",
                column: "TypeProductId",
                unique: true);
        }
    }
}
