using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatformRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platformItems = _repository.GetAllPlatforms();
            var response = _mapper.Map<IEnumerable<PlatformReadDto>>(platformItems);

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformCreateDto> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if(platformItem == null)
            {
                return NotFound();
            }

            return Ok(platformItem);
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformCreateDto);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
            
    }
}
