using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom05.Migrations
{
    /// <inheritdoc />
    public partial class Create_Foreignkey_HoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDSanPham",
                table: "HoaDons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IDSanPham",
                table: "HoaDons",
                column: "IDSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_SanPhams_IDSanPham",
                table: "HoaDons",
                column: "IDSanPham",
                principalTable: "SanPhams",
                principalColumn: "IDSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_SanPhams_IDSanPham",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_IDSanPham",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "HoaDons");
        }
    }
}
