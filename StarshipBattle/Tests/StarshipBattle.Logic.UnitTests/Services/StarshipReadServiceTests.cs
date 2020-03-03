using Moq;
using NUnit.Framework;
using StarshipBattle.Data;
using StarshipBattle.Logic.Services;
using StarshipBattle.Logic.Services.Interfaces;

namespace StarshipBattle.Logic.UnitTests.Services
{
    [TestFixture]
    public class StarshipReadServiceTests
    {
        private IStarshipReadService _starshipReadService;
        private Mock<IRepository> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository>();
            _starshipReadService = new StarshipReadService(_repositoryMock.Object);
        }

        [Test]
        public void GetAll_WhenCalled_MapsResultsToDto()
        {
            // arra
        }
    }
}
