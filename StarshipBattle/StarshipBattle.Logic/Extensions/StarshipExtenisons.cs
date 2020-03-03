using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.DTOs;

namespace StarshipBattle.Logic.Extensions
{
    public static class StarshipExtenisons
    {
        public static StarshipDto ToDto(this Starship starship)
        {
            return new StarshipDto
            {
                Id = starship.Id,
                CrewQuantity = starship.CrewQuantity,
                ImageUrl = starship.ImageUrl,
                Name = starship.Name
            };
        }

        public static Starship ToEntity(this StarshipDto starship)
        {
            return new Starship
            {
                Id = starship.Id,
                CrewQuantity = starship.CrewQuantity,
                ImageUrl = starship.ImageUrl,
                Name = starship.Name
            };
        }

        public static Starship ToEntity(this UpsertStarshipDto starship)
        {
            return new Starship
            {
                CrewQuantity = starship.CrewQuantity,
                ImageUrl = starship.ImageUrl,
                Name = starship.Name
            };
        }

        public static Starship ToEntity(this UpsertStarshipDto starship, int id)
        {
            return new Starship
            {
                Id = id,
                CrewQuantity = starship.CrewQuantity,
                ImageUrl = starship.ImageUrl,
                Name = starship.Name
            };
        }
    }
}
