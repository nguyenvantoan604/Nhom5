using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhom5.Models;
    
 [Table("NhanVien")]
 public class NhanVien
 {
    [Key]
    public string IDNhanVien{get;set;}

    public string TenNhanVien{get;set;}
    public string Tuoi{get;set;}
    public string KinhNghiem{get;set;}
    public string DiaChi{get;set;}
 }