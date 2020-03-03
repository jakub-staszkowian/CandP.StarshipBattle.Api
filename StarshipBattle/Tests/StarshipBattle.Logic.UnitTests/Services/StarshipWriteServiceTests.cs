using FluentAssertions;
using Moq;
using NUnit.Framework;
using StarshipBattle.Data;
using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.Fixture.DataGenerators;
using StarshipBattle.Logic.Services;
using StarshipBattle.Logic.Services.Interfaces;
using StarshipBattle.Logic.Validation.Exceptions;
using StarshipBattle.Logic.Validation.Interfaces;
using System;

namespace StarshipBattle.Logic.UnitTests.Services
{
    [TestFixture]
    public class StarshipWriteServiceTests
    {
        private IStarshipWriteService _starshipWriteService;
        private Mock<IRepository> _repositoryMock;
        private Mock<IAddStarshipValidator> _addStarshipValidatorMock;
        private Mock<IEditStashipValidator> _editStashipValidatorMock;
        private Mock<IRemoveStarshipValidator> _removeStarshipValidatorMock;


        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository>();
            _addStarshipValidatorMock = new Mock<IAddStarshipValidator>();
            _editStashipValidatorMock = new Mock<IEditStashipValidator>();
            _removeStarshipValidatorMock = new Mock<IRemoveStarshipValidator>();

            _starshipWriteService = new StarshipWriteService(_repositoryMock.Object,
                _addStarshipValidatorMock.Object,
                _editStashipValidatorMock.Object,
                _removeStarshipValidatorMock.Object);
        }

        [Test]
        public void Add_WhenProperModelProvided_ReturnsNewId()
        {
            // arrange
            var id = 123;
            var starship = UpsertStarshipDtoGenerator.GetValid();
            _repositoryMock
                .Setup(x => x.Add(It.IsAny<Starship>()))
                .Returns(id);

            // act
            var result = _starshipWriteService.Add(starship);

            // assert
            result.Should().Be(id);
            _repositoryMock
                .Verify(x => x.Add(It.IsAny<Starship>()), Times.Once);
            _addStarshipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Add_WhenValidationNotPassed_ReturnsZero()
        {
            // arrange
            var id = 123;
            var starship = UpsertStarshipDtoGenerator.GetWitInvalidCrewQuantity();
            _repositoryMock
                .Setup(x => x.Add(It.IsAny<Starship>()))
                .Returns(id);

            _addStarshipValidatorMock
                .Setup(x => x.Validate(It.IsAny<Starship>()))
                .Throws<ValidationException>();

            // act
            var result = _starshipWriteService.Add(starship);

            // assert
            result.Should().Be(0);
            _repositoryMock
                .Verify(x => x.Add(It.IsAny<Starship>()), Times.Never);
            _addStarshipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Add_WhenRepositoryThrowsException_ReturnsZero()
        {
            // arrange
            var id = 123;
            var starship = UpsertStarshipDtoGenerator.GetValid();
            _repositoryMock
                .Setup(x => x.Add(It.IsAny<Starship>()))
                .Throws<Exception>();

            // act
            var result = _starshipWriteService.Add(starship);

            // assert
            result.Should().Be(0);
            _repositoryMock
                .Verify(x => x.Add(It.IsAny<Starship>()), Times.Once);
            _addStarshipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Edit_WhenProperModelProvided_ReturnsTrue()
        {
            // arrange
            var id = 123;
            var starship = UpsertStarshipDtoGenerator.GetValid();

            // act
            var result = _starshipWriteService.Edit(id, starship);

            // assert
            result.Should().BeTrue();
            _repositoryMock
                .Verify(x => x.Edit(It.IsAny<Starship>()), Times.Once);
            _editStashipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Edit_WhenValidationNotPassed_ReturnsFalse()
        {
            // arrange
            var id = 123;
            var starship = UpsertStarshipDtoGenerator.GetValid();
            _editStashipValidatorMock
                .Setup(x => x.Validate(It.IsAny<Starship>()))
                .Throws<ValidationException>();

            // act
            var result = _starshipWriteService.Edit(id, starship);

            // assert
            result.Should().BeFalse();
            _repositoryMock
                .Verify(x => x.Edit(It.IsAny<Starship>()), Times.Never);
            _editStashipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Edit_WhenRepositoryThrowsException_ReturnsFalse()
        {
            // arrange
            var id = 123;
            var starship = UpsertStarshipDtoGenerator.GetValid();
            _repositoryMock
                .Setup(x => x.Edit(It.IsAny<Starship>()))
                .Throws<Exception>();

            // act
            var result = _starshipWriteService.Edit(id, starship);

            // assert
            result.Should().BeFalse();
            _repositoryMock
                .Verify(x => x.Edit(It.IsAny<Starship>()), Times.Once);
            _editStashipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Remove_WhenProperModelProvided_ReturnsTrue()
        {
            // arrange
            var id = 123;

            // act
            var result = _starshipWriteService.Remove(id);

            // assert
            result.Should().BeTrue();
            _repositoryMock
                .Verify(x => x.Remove(It.IsAny<Starship>()), Times.Once);
            _removeStarshipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Remove_WhenValidationNotPassed_ReturnsFalse()
        {
            // arrange
            var id = 123;
            _removeStarshipValidatorMock
                .Setup(x => x.Validate(It.IsAny<Starship>()))
                .Throws<ValidationException>();

            // act
            var result = _starshipWriteService.Remove(id);

            // assert
            result.Should().BeFalse();
            _repositoryMock
                .Verify(x => x.Remove(It.IsAny<Starship>()), Times.Never);
            _removeStarshipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }

        [Test]
        public void Remove_WhenRepositoryThrowsException_ReturnsFalse()
        {
            // arrange
            var id = 123;
            _repositoryMock
                .Setup(x => x.Remove(It.IsAny<Starship>()))
                .Throws<Exception>();

            // act
            var result = _starshipWriteService.Remove(id);

            // assert
            result.Should().BeFalse();
            _repositoryMock
                .Verify(x => x.Remove(It.IsAny<Starship>()), Times.Once);
            _removeStarshipValidatorMock
                .Verify(x => x.Validate(It.IsAny<Starship>()), Times.Once);
        }
    }
}
