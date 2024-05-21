using mandiri_test.Web.Models;
using mandiri_test.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace mandiri_test.Web.Controllers
{
    public class BukuController : Controller
    {
        private readonly IBukuService _bukuService;
        public BukuController(IBukuService BukuService) 
        {
            _bukuService = BukuService;
        }
        public async Task<IActionResult> BukuIndex()
        {
            List<BukuDto>? list = new();
            ResponseDto? response = await _bukuService.GetAllBukusAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BukuDto>>(Convert.ToString(response.Result));
            }
            else 
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }        

        public async Task<IActionResult> BukuCreate()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> BukuCreate(BukuDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _bukuService.CreateBukuAsync(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BukuIndex));

                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(model);
        }


        public async Task<IActionResult> BukuDelete(int BukuId)
        {
            ResponseDto? response = await _bukuService.GetBukuByIdAsync(BukuId);

            if (response != null && response.IsSuccess)
            {
                BukuDto? model = JsonConvert.DeserializeObject<BukuDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> BukuDelete(BukuDto bukuDto)
        {
            ResponseDto? response = await _bukuService.DeleteBukuByIdAsync(bukuDto.IdBuku);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(BukuIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(bukuDto);
        }

    }
}
