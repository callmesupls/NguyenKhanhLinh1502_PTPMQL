using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallmeSu_33.Models;
using Microsoft.EntityFrameworkCore;

namespace CallmeSu_33.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LopHoc> LopHocs { get; set; }
         public DbSet<SinhVien> SinhViens { get; set; }
    }
}