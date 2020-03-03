using FluentAssertions;
using NUnit.Framework;
using StarshipBattle.Logic.Extensions;
using StarshipBattle.Logic.Fixture.DataGenerators;
using StarshipBattle.Logic.Validation;
using StarshipBattle.Logic.Validation.Exceptions;
using StarshipBattle.Logic.Validation.Interfaces;
using System;

namespace StarshipBattle.Logic.UnitTests.Validation
{
    [TestFixture]
    public class AddStarshipValidatorTests
    {
        private IAddStarshipValidator _addStarshipValidator;

        [SetUp]
        public void SetUp()
        {
            _addStarshipValidator = new AddStarshipValidator();
        }

        [Test]
        public void Validate_WhenModelIsValid_DoesNotThrowException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetValid().ToEntity();

            // act
            Action act = () => _addStarshipValidator.Validate(model);

            // assert
            act.Should().NotThrow<ValidationException>();
        }

        [Test]
        public void Validate_WhenModeHasInvalidCrewQuantity_ThrowsException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetWitInvalidCrewQuantity().ToEntity();

            // act
            Action act = () => _addStarshipValidator.Validate(model);

            // assert
            act.Should().Throw<ValidationException>();
        }

        [Test]
        public void Validate_WhenModelHasInvalidName_ThrowsException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetWitInvalidName().ToEntity();

            // act
            Action act = () => _addStarshipValidator.Validate(model);

            // assert
            act.Should().Throw<ValidationException>();
        }

        [Test]
        public void Validate_WhenModeHasIdAssigned_ThrowsException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetValid().ToEntity();
            model.Id = 15;

            // act
            Action act = () => _addStarshipValidator.Validate(model);

            // assert
            act.Should().Throw<ValidationException>();
        }
    }
}
