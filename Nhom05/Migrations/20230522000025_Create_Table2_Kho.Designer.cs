﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nhom05.Data;

#nullable disable

namespace Nhom05.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230522000025_Create_Table2_Kho")]
    partial class Create_Table2_Kho
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Nhom05.Models.DanhGia", b =>
                {
                    b.Property<string>("IDDanhGia")
                        .HasColumnType("TEXT");

                    b.Property<string>("IDSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IDDanhGia");

                    b.HasIndex("IDSanPham");

                    b.ToTable("DanhGias");
                });

            modelBuilder.Entity("Nhom05.Models.HoaDon", b =>
                {
                    b.Property<string>("IDHoaDon")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IDKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IDSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("STD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TongGia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IDHoaDon");

                    b.HasIndex("IDKhachHang");

                    b.HasIndex("IDSanPham");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("Nhom05.Models.KhachHang", b =>
                {
                    b.Property<string>("IDKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IDSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("STD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IDKhachHang");

                    b.HasIndex("IDSanPham");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("Nhom05.Models.Kho", b =>
                {
                    b.Property<string>("KhoID")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChiKho")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThuongHieu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("KhoID");

                    b.ToTable("Khos");
                });

            modelBuilder.Entity("Nhom05.Models.NhanVien", b =>
                {
                    b.Property<string>("IDNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KinhNghiem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tuoi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IDNhanVien");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("Nhom05.Models.SanPham", b =>
                {
                    b.Property<string>("IDSanPham")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThuongHieu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IDSanPham");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("Nhom05.Models.DanhGia", b =>
                {
                    b.HasOne("Nhom05.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IDSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("Nhom05.Models.HoaDon", b =>
                {
                    b.HasOne("Nhom05.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("IDKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nhom05.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IDSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("Nhom05.Models.KhachHang", b =>
                {
                    b.HasOne("Nhom05.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IDSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
