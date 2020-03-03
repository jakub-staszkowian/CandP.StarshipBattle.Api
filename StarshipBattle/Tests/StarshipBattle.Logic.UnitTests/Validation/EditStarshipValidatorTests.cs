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
    public class EditStarshipValidatorTests
    {
        private IEditStashipValidator _editStarshipValidator;

        [SetUp]
        public void SetUp()
        {
            _editStarshipValidator = new EditStarshipValidator();
        }

        [Test]
        public void Validate_WhenModelIsValid_DoesNotThrowException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetValid().ToEntity();
            model.Id = 15;

            // act
            Action act = () => _editStarshipValidator.Validate(model);

            // assert
            act.Should().NotThrow<ValidationException>();
        }

        [Test]
        public void Validate_WhenModeHasInvalidCrewQuantity_ThrowsException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetWitInvalidCrewQuantity().ToEntity();
            model.Id = 15;

            // act
            Action act = () => _editStarshipValidator.Validate(model);

            // assert
            act.Should().Throw<ValidationException>();
        }

        [Test]
        public void Validate_WhenModelHasInvalidName_ThrowsException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetWitInvalidName().ToEntity();
            model.Id = 15;

            // act
            Action act = () => _editStarshipValidator.Validate(model);

            // assert
            act.Should().Throw<ValidationException>();
        }

        [Test]
        public void Validate_WhenModeHasInvalidId_ThrowsException()
        {
            // arrange
            var model = UpsertStarshipDtoGenerator.GetValid().ToEntity();
            model.Id = -15;

            // act
            Action act = () => _editStarshipValidator.Validate(model);

            // assert
            act.Should().Throw<ValidationException>();
        }
    }
}
