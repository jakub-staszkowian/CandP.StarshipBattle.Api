using System;

namespace StarshipBattle.Logic.Validation.Exceptions
{
    /// <summary>
    /// Exception thrown in case of validation errors
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
