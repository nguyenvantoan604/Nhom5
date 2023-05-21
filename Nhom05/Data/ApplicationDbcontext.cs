using Nhom05.Models;
using Microsoft.EntityFrameworkCore;

namespace Nhom05.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<KhachHang> KhachHangs {get; set;} = default!;
    // public DbSet<NhanVien> NhanViens {get; set;}
    public DbSet<SanPham> SanPhams {get; set;} = default!;
    public DbSet<HoaDon> HoaDons {get; set;}
    public DbSet<DanhGia> DanhGias {get; set;}
   



}