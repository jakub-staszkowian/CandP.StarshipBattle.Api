using StarshipBattle.Logic.Validation.Exceptions;
using StarshipBattle.Logic.Validation.Interfaces;
using System;

namespace StarshipBattle.Logic.Validation
{
    public  abstract class Validator<TModel> : IValidator<TModel>
    {
        public abstract void Validate(TModel model);

        protected void ValidateCase(TModel model, Func<TModel, bool> test, string errorMessage)
        {
            if (!test(model))
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
