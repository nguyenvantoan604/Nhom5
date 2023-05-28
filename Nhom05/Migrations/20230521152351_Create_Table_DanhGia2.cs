using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom05.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_DanhGia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGias",
                table: "DanhGias");

            migrationBuilder.AddColumn<string>(
                name: "IDDanhGia",
                table: "DanhGias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGias",
                table: "DanhGias",
                column: "IDDanhGia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGias",
                table: "DanhGias");

            migrationBuilder.DropColumn(
                name: "IDDanhGia",
                table: "DanhGias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGias",
                table: "DanhGias",
                column: "TenKhachHang");

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    IDNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: false),
                    KinhNghiem = table.Column<string>(type: "TEXT", nullable: false),
                    TenNhanVien = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.IDNhanVien);
                });
        }
    }
}
