using Microsoft.AspNetCore.Mvc;
using StarshipBattle.Logic.DTOs;
using StarshipBattle.Logic.Services.Interfaces;
using System.Collections.Generic;

namespace StarshipBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipsController : ControllerBase
    {
        private readonly IStarshipReadService _starshipReadService;
        private readonly IStarshipWriteService _starshipWriteService;

        public StarshipsController(IStarshipReadService starshipReadService,
            IStarshipWriteService starshipWriteService)
        {
            _starshipReadService = starshipReadService;
            _starshipWriteService = starshipWriteService;
        }

        [HttpGet]
        public IEnumerable<StarshipDto> GetAll()
        {
            return _starshipReadService.GetAll();
        }

        [HttpGet("{id}")]
        public StarshipDto GetById(int id)
        {
            return _starshipReadService.GetById(id);
        }

        [HttpGet("random")]
        public StarshipDto GetRandom()
        {
            return _starshipReadService.GetRandom();
        }

        [HttpPost]
        public int Add([FromBody]UpsertStarshipDto request)
        {
            return _starshipWriteService.Add(request);
        }

        [HttpPut("{id}")]
        public bool Edit(int id, [FromBody]UpsertStarshipDto request)
        {
            return _starshipWriteService.Edit(id, request);
        }

        [HttpDelete("{id}")]
        public bool Remove(int id)
        {
            return _starshipWriteService.Remove(id);
        }
    }
}