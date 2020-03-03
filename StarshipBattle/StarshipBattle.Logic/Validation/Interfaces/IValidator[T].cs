namespace StarshipBattle.Logic.Validation.Interfaces
{
    public interface IValidator<TModel> : IValidator
    {
        void Validate(TModel model);
    }
}
