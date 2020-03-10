using FluentAssertions;
using NUnit.Framework;
using StarshipBattle.Data.Entites;
using StarshipBattle.Logic.Extensions;
using StarshipBattle.Logic.Fixture.DataGenerators;

namespace StarshipBattle.Logic.UnitTests.Extensions
{
    [TestFixture]
    public class StarshipExtensionTests
    {
        [Test]
        public void ToDto_WhenNullStarshipProvided_ReturnsNull()
        {
            // arrange
            var starship = StarshipGenerator.GetNull();

            // act
            var result = starship.ToDto();

            // assert
            result.Should().BeNull();
        }

        [Test]
        public void ToDto_WhenValidStarshipProvided_ReturnsMappedDto()
        {
            // arrange
            var starship = StarshipGenerator.GetValid();

            // act
            var result = starship.ToDto();

            // assert
            result.Should().NotBeNull();
            result.Id.Should().Be(starship.Id);
            result.Name.Should().Be(starship.Name);
            result.CrewQuantity.Should().Be(starship.CrewQuantity);
            result.ImageUrl.Should().Be(starship.ImageUrl);
        }

        [Test]
        public void ToEntity_WhenNullStarshipProvided_ReturnsNull()
        {
            // arrange
            var starship = StarshipDtoGenerator.GetNull();

            // act
            var result = starship.ToEntity();

            // assert
            result.Should().BeNull();
        }

        [Test]
        public void ToEntity_WhenValidStarshipProvided_ReturnsMappedEntity()
        {
            // arrange
            var starship = StarshipDtoGenerator.GetValid();

            // act
            var result = starship.ToEntity();

            // assert
            result.Should().NotBeNull();
            result.Id.Should().Be(starship.Id);
            result.Name.Should().Be(starship.Name);
            result.CrewQuantity.Should().Be(starship.CrewQuantity);
            result.ImageUrl.Should().Be(starship.ImageUrl);
        }

        [Test]
        public void ToEntity_WhenNullUpsertStarshipDtoProvided_ReturnsNull()
        {
            // arrange
            var starship = UpsertStarshipDtoGenerator.GetNull();

            // act
            var result = starship.ToEntity();

            // assert
            result.Should().BeNull();
        }

        [Test]
        public void ToEntity_WhenValidUpsertStarshipDtoWithoutIdProvided_ReturnsMappedEntity()
        {
            // arrange
            var starship = UpsertStarshipDtoGenerator.GetValid();

            // act
            var result = starship.ToEntity();

            // assert
            result.Should().NotBeNull();
            result.Name.Should().Be(starship.Name);
            result.CrewQuantity.Should().Be(starship.CrewQuantity);
            result.ImageUrl.Should().Be(starship.ImageUrl);
        }

        [Test]
        public void ToEntity_WhenValidUpsertStarshipDtoWithIdProvided_ReturnsMappedEntity()
        {
            // arrange
            var starship = UpsertStarshipDtoGenerator.GetValid();
            var starshipId = 123;

            // act
            var result = starship.ToEntity(starshipId);

            // assert
            result.Should().NotBeNull();
            result.Id.Should().Be(starshipId);
            result.Name.Should().Be(starship.Name);
            result.CrewQuantity.Should().Be(starship.CrewQuantity);
            result.ImageUrl.Should().Be(starship.ImageUrl);
        }
    }
}

