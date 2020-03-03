using StarshipBattle.Data;
using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.DTOs;
using StarshipBattle.Logic.Extensions;
using StarshipBattle.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarshipBattle.Logic.Services
{
    public class StarshipReadService : IStarshipReadService
    {
        private readonly IRepository _repository;

        public StarshipReadService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<StarshipDto> GetAll()
        {
            return _repository
                .GetAll<Starship>()
                .Select(s => s.ToDto());
        }

        public StarshipDto GetById(int id)
        {
            return _repository
                .Get<Starship>(id)
                .ToDto();
        }

        public StarshipDto GetRandom()
        {
            return _repository
                .GetAll<Starship>()
                .OrderBy(s => Guid.NewGuid())
                .FirstOrDefault()
                .ToDto();
        }
    }
}
