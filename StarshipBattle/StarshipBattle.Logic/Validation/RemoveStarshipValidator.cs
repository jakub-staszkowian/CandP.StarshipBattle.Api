using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.Validation.Interfaces;

namespace StarshipBattle.Logic.Validation
{
    public class RemoveStarshipValidator : Validator<Starship>, IRemoveStarshipValidator
    {
        public override void Validate(Starship model)
        {
            ValidateCase(model, m => m != null, "Not added Starship cannot have id"); ;
        }
    }
}
