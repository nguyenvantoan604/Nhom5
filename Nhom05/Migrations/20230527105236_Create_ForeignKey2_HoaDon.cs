using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom05.Migrations
{
    /// <inheritdoc />
    public partial class Create_ForeignKey2_HoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDNhanVien",
                table: "HoaDons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IDNhanVien",
                table: "HoaDons",
                column: "IDNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_NhanVien_IDNhanVien",
                table: "HoaDons",
                column: "IDNhanVien",
                principalTable: "NhanVien",
                principalColumn: "IDNhanVien",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_NhanVien_IDNhanVien",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_IDNhanVien",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "IDNhanVien",
                table: "HoaDons");
        }
    }
}
