using StarshipBattle.Data;
using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.DTOs;
using StarshipBattle.Logic.Extensions;
using StarshipBattle.Logic.Services.Interfaces;
using StarshipBattle.Logic.Validation.Interfaces;

namespace StarshipBattle.Logic.Services
{
    public class StarshipWriteService : IStarshipWriteService
    {
        private readonly IRepository _repository;
        private readonly IAddStarshipValidator _addStarshipValidator;
        private readonly IEditStashipValidator _editStashipValidator;
        private readonly IRemoveStarshipValidator _removeStarshipValidator;

        public StarshipWriteService(IRepository repository,
            IAddStarshipValidator addStarshipValidator,
            IEditStashipValidator editStashipValidator,
            IRemoveStarshipValidator removeStarshipValidator)
        {
            _repository = repository;
            _addStarshipValidator = addStarshipValidator;
            _editStashipValidator = editStashipValidator;
            _removeStarshipValidator = removeStarshipValidator;
        }

        public int Add(UpsertStarshipDto starshipDto)
        {
            try
            {
                var starship = starshipDto.ToEntity();
                _addStarshipValidator.Validate(starship);
                return _repository.Add(starshipDto.ToEntity());
            }
            catch
            {
                return 0;
            }
        }

        public bool Edit(int id, UpsertStarshipDto starshipDto)
        {
            try
            {
                var starship = starshipDto.ToEntity(id);
                _editStashipValidator.Validate(starship);
                _repository.Edit(starship);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var starship = _repository.Get<Starship>(id);
                _removeStarshipValidator.Validate(starship);
                _repository.Remove(starship);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
