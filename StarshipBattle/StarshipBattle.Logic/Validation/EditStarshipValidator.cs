using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.Validation.Interfaces;

namespace StarshipBattle.Logic.Validation
{
    public class EditStarshipValidator : Validator<Starship>, IEditStashipValidator
    {
        public override void Validate(Starship model)
        {
            ValidateCase(model, m => m.Id > default(int), "Invalid Starship id provided");
            ValidateCase(model, m => !string.IsNullOrEmpty(m.Name), "Starship has to have name");
            ValidateCase(model, m => m.CrewQuantity > default(int), "Invalid crew quantity provided");
        }
    }
}
