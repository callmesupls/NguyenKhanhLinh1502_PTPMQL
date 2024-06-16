using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallmeSu_33.Models
{
    [Table("SinhVien")] //Tên bảng
    public class SinhVien
    {
        [Key] //đánh dấu là khóa chính
        [StringLength(20)] //độ dài tối đa là 20 (Vì StringLength auto là kiểu nvarchar nên phải thêm dòng dưới)
        [Column(TypeName = "varchar(20)")]
        public string MasinhVien { get; set; }
        [StringLength(50)]
        public string HoTen { get; set; }

        public int MaLop { get; set; }
        [ForeignKey("MaLop")] //Nối tới khóa chính của bảng LopHoc
        public LopHoc LopHoc { get; set; } 
    }
}