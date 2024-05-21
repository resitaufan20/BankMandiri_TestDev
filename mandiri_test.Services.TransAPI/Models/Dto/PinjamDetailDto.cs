using System.ComponentModel.DataAnnotations.Schema;

namespace mandiri_test.Services.TransAPI.Models.Dto
{
	public class PinjamDetailDto
	{
		public int IdTransDetail { get; set; }
		public int IdTrans { get; set; }
		public int IdBuku { get; set; }
        public string? Judul { get; set; }
    }
}
