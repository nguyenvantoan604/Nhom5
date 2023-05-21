using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhom05.Models;

 [Table("KhachHangs")]
 public class KhachHang{
  [Key]
    public string IDKhachHang {get;set;}
      
    public string TenKhachHang {get;set;}
    public string STD {get;set;}
    public string DiaChi {get;set;}
    public string IDSanPham{get;set;}
    [ForeignKey("IDSanPham")]

    public SanPham? SanPham {get;set;}

 }