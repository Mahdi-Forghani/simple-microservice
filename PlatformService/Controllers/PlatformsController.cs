using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Model;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> getting all platforms...");

            var platforms = _platformRepo.GetAllPlatfomrs();

            var result = _mapper.Map<List<PlatformReadDto>>(platforms);

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {

            Console.WriteLine("--> getting individual platform...");

            var platform = _platformRepo.GetPlatformById(id);

            if (platform == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<PlatformReadDto>(platform);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformDto)
        {
            var platform = _mapper.Map<Platform>(platformDto);
            _platformRepo.CreatePlatform(platform);
            _platformRepo.SaveChanges();

            var result = _mapper.Map<PlatformReadDto>(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new { id = result.Id }, result);
        }
    }
}