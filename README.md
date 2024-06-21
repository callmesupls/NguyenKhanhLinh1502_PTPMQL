<h1>Bài của Nguyễn Khánh Linh</h1>
<h1>Cách làm bài thi điểm (Khoảng 5 điểm no code)</h1>

# *1. Tạo project
```sh
dotnet new mvc -o NKL_33
```

# *2. Trỏ vào project vừa tạo, hoặc dùng VS code vào thẳng thư mục cho nhanh
```sh
cd NKL_33
```

# *3. Sau khi đã tạo project thì chạy những lệnh (Cài thư viện/package) sau:
```sh
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design 
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package EPPlus
dotnet add package X.PagedList.Mvc.Core --version 8.4.7
dotnet add package BCrypt.Net-Next --version 4.0.3
```

# 4. Đọc đề bài và tạo các bảng, tạo trong Models, lưu ý là KHÔNG CẦN BIẾT LÀM GÌ, PHẢI KHAI BÁO TÊN BẢNG ([Table("")] ) VÀ  KHOÁ CHÍNH ( [Key] ) Nếu đầu bài KHÔNG YÊU CẦU TÊN KHOÁ NGOẠI thì cứ đặt là:
```sh
 public int Id { get, set }
 ```
# Ví dụ Bảng kế thừa:
```sh
    public class Employee : Person //(Lưu ý là khi kế thừa thì sẽ không khai báo [Key] tức là khoá chính)
```
# Ví dụ Bảng đơn:
```sh
    [Table("LopHoc")] //Tên bảng 
    public class LopHoc
    {
        [Key] //đánh dấu là khóa chính 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // tự tăng 
        public int MaLop{ get; set; }

        [StringLength(60)]  //Vì StringLength auto là kiểu nvarchar 
        public string TenLop{ get; set; } 
    }
```
# Ví dụ Bảng Nối (Khoá ngoại):
# Cách nối bảng xem ở dưới
```sh
    [Table("SinhVien")] //Tên bảng
    public class SinhVien
    {
        [StringLength(50)]
        public string HoTen { get; set; }

        [Key] //đánh dấu là khóa chính
        [StringLength(20)] //độ dài tối đa là 20 (Vì StringLength auto là kiểu nvarchar nên phải thêm dòng dưới)
        [Column(TypeName = "varchar(20)")]
        public string MasinhVien { get; set; }

        public int MaLop{ get; set; }
        [ForeignKey("MaLop")] //Nối tới khóa chính của bảng LopHoc (khai báo khoá ngoại)
        public LopHoc LopHoc { get; set; }
    }
```

# 5. Tạo thư mục Data, rồi tạo file .cs
```sh
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //Khai báo đối tượng để tạo database

        public DbSet<LopHoc> LopHocs { get; set; }
        
        //Kết thúc khai báo đối tượng để tạo database
    }
```

# *6. Vào file appsettings.json, và dán vào :
TenTheoDeBai = tên trong đề bài của thầy, nếu không yêu cầu gì thì đặt tuỳ ý (Ví dụ như database.db)
```sh
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=TenTheoDeBai.db; Cache=Shared"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

# *7. Vào file Program.cs, và dán vào (dán dưới dòng 'var builder = WebApplication.CreateBuilder(args);' ) Đoạn nào báo lỗi thì click chuột vào lỗi và ấn Ctrl + . => Chọn dòng đầu để import thư viện:
```sh
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new
    InvalidOperationException("Connection string 'DefaultConnection' not found.")));
```
# 8. Chạy lệnh sau để tạo Migrations và database:
# Đến đây có thể tắt các file (Program.cs, appsettings.json)
```sh
dotnet ef migrations add Create_Database
dotnet ef database update
```
# 9. Chạy lệnh sau để tự động sinh code (Table đơn thì không cần sửa, còn Table có khoá ngoại thì phải sửa đoạn validate form):
# Bài khác thì phải sửa 3 chỗ là SinhVien hoặc LopHoc, và tên project (CallmeSu_33) theo đầu bài
# Thay từ PHAISUA theo bảng mình đang làm
# Thay từ TENBANGNOI theo tên bảng mình nối đến
# Thay từ PHAISUATENDUAN theo trên project mình tạo
# Quay lại bước 4,5 và bước 8
```sh
dotnet aspnet-codegenerator controller -name PHAISUAController -m PHAISUA -dc PHAISUATENDUAN.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite

dotnet aspnet-codegenerator controller -name TeacherController -m Teacher -dc NKL_152.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
```

# 10. Sau khi sinh code cho bảng có KHOÁ NGOẠI, thì phải thêm đoạn này trong controller. Cái này chỉ áp dụng bảng có khoá ngoại (Vào trong controller cái bảng vừa tạo)
```sh
ModelState.Remove("TENBANGNOI");
ModelState.Remove("CongTy");
ModelState.IsValid
```

# 11. Cách nối bảng:
```sh
1. Viết lại thuộc tính của khoá chính bảng cần nối
2. Khai báo [ForeignKey("")]
3. Khai báo đối tượng
```

# 12. Đến có thể dotnet run để chạy thử bảng, nếu làm tiếp thì Ctrl + C  x2 để tắt local

# 13. Cách up github:
# Lần đầu:
```sh
1. Lần đầu là chọn lựa chọn 2 (Publish to GitHub)
2. Xong lại chọn lựa chọn 2 (Publish to GitHub public repository)
3. Ấn OK
4. Xong chờ tải xong lên github, hiện thông báo "Open on GitHub" ấn vào link để copy link gửi thầy
```
# Lần sau:
```sh
1. Viết commit name theo yêu cầu đề bài. VD: commit name là + Họ tên sinh viên viết tắt + 3 số cuối mã sinh viên + "_Cau1".
2. Thì sẽ viết ở ô message là NKL391_Cau1. Tiếp theo ấn nút Commit, Tiếp theo nữa ấn Sync Changes là xong
3. 
```





-------------------------------------------------------------------------------------------------------------------------------------------------
<h1>Cách làm câu 1</h1>





# Bước một chạy lệnh:
```sh
dotnet new console --name TinhGiaiThua
```

# Bước 2: vào project vừa tạo:
```sh
cd TinhGiaiThua
```

# Bước 3: Vào file Program.cs và copy đoạn code tính giai thừa sau (Xoá sạch code trong file và copy vào):
# Nếu bài khác có thể dùng chatgpt để lấy code xong dán vào
```sh
using System;

class Program
{
    // Hàm tính giai thừa của một số nguyên dương
    static long TinhGiaiThua(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        
        long giaiThua = 1;
        for (int i = 2; i <= n; i++)
        {
            giaiThua *= i;
        }
        return giaiThua;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Nhap so nguyen duong n de tinh giai thua:");
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("Khong tinh đuoc giai thua cua so am.");
        }
        else
        {
            long ketQua = TinhGiaiThua(n);
            Console.WriteLine($"Giai thua cua {n} la: {ketQua}");
        }
    }
}
```

# Bước 4: Chạy chương trình:
```sh
dotnet run
```