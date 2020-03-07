using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.DTOs;

namespace StarshipBattle.Logic.Extensions
{
    public static class StarshipExtenisons
    {
        public static StarshipDto ToDto(this Starship starship)
        {
            if (starship == null)
            {
                return null;
            }

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
            if (starship == null)
            {
                return null;
            }

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
            if (starship == null)
            {
                return null;
            }

            return ToEntity(starship, 0);
        }

        public static Starship ToEntity(this UpsertStarshipDto starship, int id)
        {
            if (starship == null)
            {
                return null;
            }

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
