<h1>Bài của Nguyễn Khánh Linh</h1>
<h1>Cách làm bài thi điểm (Khoảng 5 điểm no code)</h1>
<h1></h1>
<h2></h2>

#1. Tạo project
```sh
dotnet new mvc -o CallmeSu_33
```

#2. Trỏ vào project vừa tạo, hoặc dùng VS code vào thẳng cho nhanh
```sh
cd CallmeSu_33
```

#3. Sau khi đã tạo project thì chạy những lệnh sau:
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

#4. Tạo thư mục Data, rồi tạo file ApplicationDbContext.cs:
```sh
public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Linh> Linhs { get; set; }
    }
```

#5. Vào file appsettings.json, và dán vào:
```sh
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=Test.db; Cache=Shared"
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

#6. Vào file Program.cs, và dán vào (dán dưới dòng 'var builder = WebApplication.CreateBuilder(args);' ) Đoạn nào báo lỗi thì click chuột vào lỗi và ấn Ctrl + . => Chọn dòng đầu để import thư viện:
```sh
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new
    InvalidOperationException("Connection string 'DefaultConnection' not found.")));
```
#7. Chạy lệnh sau để tạo Migrations và database:
```sh
dotnet ef migrations add Create_database
dotnet ef database update
```
#8. Chạy lệnh sau để tự động sinh code (Table đơn thì không cần sửa, còn Table có khoá ngoại thì phải sửa đoạn validate form):
```sh
dotnet aspnet-codegenerator controller -name SinhVienController -m SinhVien -dc CallmeSu_33.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
```
```sh
dotnet aspnet-codegenerator controller -name LopHocController -m LopHoc -dc CallmeSu_33.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
```

<img src="Đề thi kết thúc học phần.JPG" alt="Đề thi kết thúc học phần">
