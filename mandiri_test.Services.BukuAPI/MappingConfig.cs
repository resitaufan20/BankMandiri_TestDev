using AutoMapper;
using mandiri_test.Services.BukuAPI.Models;
using mandiri_test.Services.BukuAPI.Models.Dto;

namespace mandiri_test.Services.BukuAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BukuDto, Buku>().ReverseMap();
                config.CreateMap<Buku, BukuDto>();
            });
            return mappingConfig;
        }
    }
}
