using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhom05.Models;

[Table("Khos")]
public class Kho{
    [Key]
    public string KhoID {get;set;}
    public string TenKho {get;set;}
    public string TenSanPham {get;set;}
    public string ThuongHieu {get;set;}

    public string DiaChiKho {get;set;}
}
