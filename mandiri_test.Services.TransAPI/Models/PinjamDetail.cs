using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandiri_test.Services.TransAPI.Models
{
	public class PinjamDetail
	{
		[Key]
		public int IdTransDetail { get; set; }
        public int IdTrans { get; set; }
        public int IdBuku { get; set; }
		[ForeignKey("IdTrans")]
		public Pinjam? Pinjam { get; set; }
	}
}
