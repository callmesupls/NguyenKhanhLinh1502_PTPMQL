using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallmeSu_33.Models
{
    [Table("LopHoc")] //Tên bảng
    public class LopHoc
    {
        [Key] //đánh dấu là khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLop{ get; set; }
         [StringLength(60)] 
        public string TenLop{ get; set; }

        
    }
}