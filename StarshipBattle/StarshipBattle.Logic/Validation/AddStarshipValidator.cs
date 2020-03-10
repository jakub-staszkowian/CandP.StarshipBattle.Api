using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.Validation.Interfaces;

namespace StarshipBattle.Logic.Validation
{
    public class AddStarshipValidator : Validator<Starship>, IAddStarshipValidator
    {
        public override void Validate(Starship model)
        {
            ValidateCase(model, m => m.Id == default(int), "Not added Starship cannot have id");
            ValidateCase(model, m => !string.IsNullOrEmpty(m.Name), "Starship has to have name");
            ValidateCase(model, m => m.CrewQuantity > default(int), "Invalid crew quantity provided");
        }
    }
}
