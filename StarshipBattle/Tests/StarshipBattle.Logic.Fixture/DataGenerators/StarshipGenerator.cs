using StarshipBattle.Data.Entites;

namespace StarshipBattle.Logic.Fixture.DataGenerators
{
    public class StarshipGenerator
    {
        public static Starship GetNull()
        {
            return null;
        }

        public static Starship GetValid()
        {
            return new Starship
            {
                Id = 1,
                CrewQuantity = 4,
                ImageUrl = "www.google.com",
                Name = "Name"
            };
        }
    }
}
