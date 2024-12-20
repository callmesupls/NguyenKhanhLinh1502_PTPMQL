﻿// <auto-generated />
using CallmeSu_33.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CallmeSu_33.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240614165451_Create_database_v2")]
    partial class Create_database_v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("CallmeSu_33.Models.LopHoc", b =>
                {
                    b.Property<int>("MaLop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.HasKey("MaLop");

                    b.ToTable("LopHocs");
                });

            modelBuilder.Entity("CallmeSu_33.Models.SinhVien", b =>
                {
                    b.Property<string>("MasinhVien")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("MaLop")
                        .HasColumnType("INTEGER");

                    b.HasKey("MasinhVien");

                    b.HasIndex("MaLop");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("CallmeSu_33.Models.SinhVien", b =>
                {
                    b.HasOne("CallmeSu_33.Models.LopHoc", "LopHoc")
                        .WithMany()
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LopHoc");
                });
#pragma warning restore 612, 618
        }
    }
}
