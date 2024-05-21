using System.ComponentModel.DataAnnotations;

namespace mandiri_test.Services.BukuAPI.Models
{
    public class Buku
    {
        [Key]
        public int IdBuku { get; set; }
        [Required]
        public string Judul { get; set; }
        public string Pengarang { get; set; }
        public string Penerbit { get; set; }
        public int TahunTerbit { get; set; }
        [Required]
        public double Harga { get; set; }
        [Required]
        public int JumlahBuku { get; set; }
    }
}
