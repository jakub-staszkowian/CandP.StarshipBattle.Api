namespace StarshipBattle.Logic.Validation.Interfaces
{
    public interface IValidator<TModel>
    {
        void Validate(TModel model);
    }
}
