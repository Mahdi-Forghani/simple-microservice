using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Model;

namespace PlatformService.AutoMapperProfiles
{
    public class DefaultProfiles : Profile
    {
        public DefaultProfiles()
        {
            // source => target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}