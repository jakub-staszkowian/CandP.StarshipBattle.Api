namespace StarshipBattle.Data.Entites
{
    public class Starship : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int CrewQuantity { get; set; }
    }
}
