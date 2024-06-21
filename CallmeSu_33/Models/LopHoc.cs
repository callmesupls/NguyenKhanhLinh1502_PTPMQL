using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallmeSu_33.Models
{
    [Table("LopHoc")] //Tên bảng (nên copy)
    public class LopHoc
    {
        [Key] //đánh dấu là khóa chính (nên copy)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //(nên copy)
        public int MaLop{ get; set; }
         [StringLength(60)]  //(nên copy)
        public string TenLop{ get; set; } //(nên copy)

        
    }
}