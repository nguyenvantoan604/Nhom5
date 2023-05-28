using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhom05.Models;

 [Table("HoaDons")]
 public class HoaDon{
  [Key]
    public string IDHoaDon {get;set;}
    public string IDKhachHang{get;set;}
    [ForeignKey("IDKhachHang")]
    public KhachHang? KhachHang {get;set;}

    public string IDSanPham{get;set;}
    [ForeignKey("IDSanPham")]
    public SanPham? SanPham {get;set;}

      
    public string DiaChi {get;set;}
    public string STD {get;set;}
    public string TongGia {get;set;}
     public string IDNhanVien{get;set;}
    [ForeignKey("IDNhanVien")]
    public NhanVien? NhanVien {get;set;}

   
 }