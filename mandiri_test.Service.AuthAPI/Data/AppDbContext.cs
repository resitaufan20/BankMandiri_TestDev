using mandiri_test.Services.BukuAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace mandiri_test.Service.AuthAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Buku> Buku_ { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Buku>().HasData(new Buku
            {
                 IdBuku = 1,
                 Judul = "Anilsa Keuangan",
                 Pengarang = "Tobby",
                 Penerbit = "Media 1",
                 TahunTerbit = 1999,
                 Harga  = 29000,
                 JumlahBuku = 20
            });

            modelBuilder.Entity<Buku>().HasData(new Buku
            {
                IdBuku = 2,
                Judul = "Keuangan",
                Pengarang = "P Tobby",
                Penerbit = "Media 1",
                TahunTerbit = 1999,
                Harga = 35000,
                JumlahBuku = 10
            });
        }

    }
}
