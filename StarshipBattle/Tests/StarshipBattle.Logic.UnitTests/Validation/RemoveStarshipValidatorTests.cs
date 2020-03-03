using FluentAssertions;
using NUnit.Framework;
using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.Extensions;
using StarshipBattle.Logic.Fixture.DataGenerators;
using StarshipBattle.Logic.Validation;
using StarshipBattle.Logic.Validation.Exceptions;
using StarshipBattle.Logic.Validation.Interfaces;
using System;

namespace StarshipBattle.Logic.UnitTests.Validation
{
    [TestFixture]
    public class RemoveStarshipValidatorTests
    {
        private IRemoveStarshipValidator _removeStarshipValidator;

        [SetUp]
        public void SetUp()
        {
            _removeStarshipValidator = new RemoveStarshipValidator();
        }

        [Test]
        public void Validate_WhenModelIsValid_DoesNotThrowException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetValid().ToEntity();
            model.Id = 15;

            // act
            Action act = () => _removeStarshipValidator.Validate(model);

            // assert
            act.Should().NotThrow<ValidationException>();
        }

        [Test]
        public void Validate_WhenModelIsNull_ThrowsException()
        {
            // arrange
            Starship model = null;

            // act
            Action act = () => _removeStarshipValidator.Validate(model);

            // assert
            act.Should().Throw<ValidationException>();
        }
    }
}
