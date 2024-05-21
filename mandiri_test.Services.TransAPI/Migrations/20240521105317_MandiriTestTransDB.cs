using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mandiri_test.Services.TransAPI.Migrations
{
    /// <inheritdoc />
    public partial class MandiriTestTransDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pinjam",
                columns: table => new
                {
                    IdTrans = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TanggalPinjam = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pinjam", x => x.IdTrans);
                });

            migrationBuilder.CreateTable(
                name: "PinjamDetail",
                columns: table => new
                {
                    IdTransDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTrans = table.Column<int>(type: "int", nullable: false),
                    IdBuku = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinjamDetail", x => x.IdTransDetail);
                    table.ForeignKey(
                        name: "FK_PinjamDetail_Pinjam_IdTrans",
                        column: x => x.IdTrans,
                        principalTable: "Pinjam",
                        principalColumn: "IdTrans",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PinjamDetail_IdTrans",
                table: "PinjamDetail",
                column: "IdTrans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PinjamDetail");

            migrationBuilder.DropTable(
                name: "Pinjam");
        }
    }
}
