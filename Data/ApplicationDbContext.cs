using Nhom5.Models;
using Microsoft.EntityFrameworkCore;

namespace Nhom5.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Kho> Khos {get; set;}
    public DbSet<NhanVien> NhanViens { get; set; }
}