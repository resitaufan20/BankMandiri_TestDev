namespace mandiri_test.Services.TransAPI.Models.Dto
{
	public class PinjamDto
	{
		public int IdTrans { get; set; }
		public DateTime? TanggalPinjam { get; set; }
		public string? UserName { get; set; }
		public IEnumerable<PinjamDetailDto> PinjamDetails { get; set; }
	}


}
