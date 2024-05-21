using AutoMapper;
using mandiri_test.Services.TransAPI.Data;
using mandiri_test.Services.TransAPI.Models;
using mandiri_test.Services.TransAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace mandiri_test.Services.TransAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PinjamController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;
		private readonly IHttpClientFactory _clientFactory;

		public PinjamController(AppDbContext db, IMapper mapper, IHttpClientFactory clientFactory)
		{
			_db = db;
			_mapper = mapper;
			_clientFactory = clientFactory;
			_response = new ResponseDto();
		}

		[HttpPost]
		public async Task<ResponseDto> Post([FromBody] PinjamDto pinjamDto) {
			try
			{
				var username = User.FindFirst("name").Value;
				Pinjam obj = _mapper.Map<Pinjam>(pinjamDto);
				obj.UserName = username;
				obj.TanggalPinjam = DateTime.Now;
				
				List<int>  idListBuku = new List<int>();
				idListBuku = obj.PinjamDetails.Select(s => s.IdBuku).ToList();

				var client = _clientFactory.CreateClient("Master");
				var response = await client.PostAsJsonAsync($"/api/buku/UpdateJumlah",idListBuku);
				var apiContet = await response.Content.ReadAsStringAsync();
				var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
				if (!resp.IsSuccess)
				{
					_response.IsSuccess = false;
					_response.Message = "Gagal Update Jumlah";
					return _response;
				}

				_db.Pinjam.Add(obj);
				await _db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	}
}
