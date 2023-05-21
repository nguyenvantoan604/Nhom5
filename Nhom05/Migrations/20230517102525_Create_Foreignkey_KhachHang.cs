using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom05.Migrations
{
    /// <inheritdoc />
    public partial class Create_Foreignkey_KhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDSanPham",
                table: "KhachHangs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IDKhachHang",
                table: "HoaDons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_IDSanPham",
                table: "KhachHangs",
                column: "IDSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IDKhachHang",
                table: "HoaDons",
                column: "IDKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_IDSanPham",
                table: "DanhGias",
                column: "IDSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGias_SanPhams_IDSanPham",
                table: "DanhGias",
                column: "IDSanPham",
                principalTable: "SanPhams",
                principalColumn: "IDSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_KhachHangs_IDKhachHang",
                table: "HoaDons",
                column: "IDKhachHang",
                principalTable: "KhachHangs",
                principalColumn: "IDKhachHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHangs_SanPhams_IDSanPham",
                table: "KhachHangs",
                column: "IDSanPham",
                principalTable: "SanPhams",
                principalColumn: "IDSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhGias_SanPhams_IDSanPham",
                table: "DanhGias");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_KhachHangs_IDKhachHang",
                table: "HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_KhachHangs_SanPhams_IDSanPham",
                table: "KhachHangs");

            migrationBuilder.DropIndex(
                name: "IX_KhachHangs_IDSanPham",
                table: "KhachHangs");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_IDKhachHang",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_DanhGias_IDSanPham",
                table: "DanhGias");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "KhachHangs");

            migrationBuilder.DropColumn(
                name: "IDKhachHang",
                table: "HoaDons");
        }
    }
}
