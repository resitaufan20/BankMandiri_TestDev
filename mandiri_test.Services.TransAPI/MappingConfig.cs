using AutoMapper;
using mandiri_test.Services.TransAPI.Models;
using mandiri_test.Services.TransAPI.Models.Dto;

namespace mandiri_test.Services.TransAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PinjamDto, Pinjam>().ReverseMap();
                config.CreateMap<PinjamDetail,PinjamDetailDto >().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
