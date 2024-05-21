using AutoMapper;
using mandiri_test.Services.BukuAPI.Data;
using mandiri_test.Services.BukuAPI.Models;
using mandiri_test.Services.BukuAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mandiri_test.Services.BukuAPI.Controllers
{
    [Route("api/buku")]
    [ApiController]
    public class BukuAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public BukuAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Buku> objlist = _db.Buku_.ToList();
                _response.Result = _mapper.Map<IEnumerable<BukuDto>>(objlist);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Buku obj = _db.Buku_.First(u => u.IdBuku == id);
                _response.Result = _mapper.Map<BukuDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        
        [HttpPost]
        public ResponseDto Post([FromBody] BukuDto bukuDto)
        {
            try
            {
                Buku obj = _mapper.Map<Buku>(bukuDto);
                _db.Buku_.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<BukuDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

		[HttpPost("UpdateJumlah")]
		public async Task<ResponseDto> UpdateJumlah([FromBody] List<int> idList)
		{
			try
			{
                var listBuku = await _db.Buku_.Where(w => idList.Contains(w.IdBuku)).ToListAsync();

                foreach (var item in listBuku)
                {
                    item.JumlahBuku--;
                }

				_db.SaveChanges();
				_response.Result = null;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;

			}
			return _response;
		}

		[HttpPut]
        public ResponseDto Put([FromBody] BukuDto couponDto)
        {
            try
            {
                Buku obj = _mapper.Map<Buku>(couponDto);
                _db.Buku_.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<BukuDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]

        public ResponseDto Delete(int id)
        {
            try
            {
                Buku obj = _db.Buku_.First(u => u.IdBuku == id);
                _db.Buku_.Remove(obj);
                _db.SaveChanges();
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

