using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallmeSu_33.Migrations
{
    /// <inheritdoc />
    public partial class Create_database_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    MasinhVien = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MaLop = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.MasinhVien);
                    table.ForeignKey(
                        name: "FK_SinhViens_LopHocs_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHocs",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MaLop",
                table: "SinhViens",
                column: "MaLop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhViens");
        }
    }
}
