using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhom05.Models;

 [Table("DanhGias")]
 public class DanhGia{
  [Key]
   
   public string IDDanhGia {get;set;  }
     public string TenKhachHang {get;set;}
    public string NoiDung {get;set;}
    
     public string IDSanPham{get;set;}
    [ForeignKey("IDSanPham")]

    public SanPham? SanPham {get;set;}
    
 }