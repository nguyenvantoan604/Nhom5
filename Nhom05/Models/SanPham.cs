using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhom05.Models;
 [Table("SanPhams")]
public class SanPham{
    [Key]
    public string IDSanPham {get;set;}
    public string TenSanPham {get;set;}
   
     public string ThuongHieu {get;set;}
    public string Gia {get;set;}
}