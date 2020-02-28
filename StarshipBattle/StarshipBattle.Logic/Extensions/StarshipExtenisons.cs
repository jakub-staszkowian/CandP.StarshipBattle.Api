using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
