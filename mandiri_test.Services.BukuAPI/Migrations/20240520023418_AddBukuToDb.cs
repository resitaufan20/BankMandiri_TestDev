using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mandiri_test.Services.BukuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBukuToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buku_",
                columns: table => new
                {
                    IdBuku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pengarang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penerbit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TahunTerbit = table.Column<int>(type: "int", nullable: false),
                    Harga = table.Column<double>(type: "float", nullable: false),
                    JumlahBuku = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buku_", x => x.IdBuku);
                });

            migrationBuilder.InsertData(
                table: "Buku_",
                columns: new[] { "IdBuku", "Harga", "Judul", "JumlahBuku", "Penerbit", "Pengarang", "TahunTerbit" },
                values: new object[,]
                {
                    { 1, 29000.0, "Anilsa Keuangan", 20, "Media 1", "Tobby", 1999 },
                    { 2, 35000.0, "Keuangan", 10, "Media 1", "P Tobby", 1999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buku_");
        }
    }
}
