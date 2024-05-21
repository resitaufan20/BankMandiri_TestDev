using System.ComponentModel.DataAnnotations;

namespace mandiri_test.Services.TransAPI.Models
{
	public class Pinjam
	{
		[Key]
		public int IdTrans { get; set; }
        public DateTime? TanggalPinjam { get; set; }
        public string UserName { get; set; }
		public IEnumerable<PinjamDetail> PinjamDetails { get; set; }
	}
}
