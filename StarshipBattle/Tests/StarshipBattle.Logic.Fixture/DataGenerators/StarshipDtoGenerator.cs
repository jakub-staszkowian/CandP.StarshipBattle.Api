using StarshipBattle.Logic.DTOs;

namespace StarshipBattle.Logic.Fixture.DataGenerators
{
    public class StarshipDtoGenerator
    {
        public static StarshipDto GetNull()
        {
            return null;
        }

        public static StarshipDto GetValid()
        {
            return new StarshipDto
            {
                Id = 1,
                CrewQuantity = 4,
                ImageUrl = "www.google.com",
                Name = "Name"
            };
        }
    }
}
