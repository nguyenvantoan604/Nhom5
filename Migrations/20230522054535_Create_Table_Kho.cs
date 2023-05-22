using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom5.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Kho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khos",
                columns: table => new
                {
                    KhoID = table.Column<string>(type: "TEXT", nullable: false),
                    TenKho = table.Column<string>(type: "TEXT", nullable: false),
                    TenSanPham = table.Column<string>(type: "TEXT", nullable: false),
                    ThuongHieu = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChiKho = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khos", x => x.KhoID);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    TenNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    Tuoi = table.Column<string>(type: "TEXT", nullable: false),
                    KinhNghiem = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IDNhanVien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khos");

            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
