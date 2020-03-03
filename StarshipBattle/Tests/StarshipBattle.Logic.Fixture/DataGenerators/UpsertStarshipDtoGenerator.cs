using StarshipBattle.Logic.DTOs;

namespace StarshipBattle.Logic.Fixture.DataGenerators
{
    public class UpsertStarshipDtoGenerator
    {
        public static UpsertStarshipDto GetValid()
        {
            return new UpsertStarshipDto
            {
                CrewQuantity = 7, 
                ImageUrl = "",
                Name = "name"
            };
        }

        public static UpsertStarshipDto GetWitInvalidName()
        {
            return new UpsertStarshipDto
            {
                CrewQuantity = 7,
                ImageUrl = "",
                Name = string.Empty
            };
        }

        public static UpsertStarshipDto GetWitInvalidCrewQuantity()
        {
            return new UpsertStarshipDto
            {
                CrewQuantity = -3,
                ImageUrl = "",
                Name = "name"
            };
        }
    }
}
