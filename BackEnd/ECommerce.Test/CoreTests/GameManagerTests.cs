using AutoFixture;
using Moq;
using ECommerce.Core.Data.Interfaces;
using ECommerce.Core.Entities;
using ECommerce.Core.Entities.Interfaces;
using ECommerce.Core.Managers;
using System;
using System.Threading.Tasks;
using Xunit;
using ECommerce.Core.Entities.FilterEntities;
using System.Linq;

namespace ECommerce.Test.CoreTests
{
    [CollectionDefinition("UsersManagerTests", DisableParallelization = true)]
    public class GameManagerTests
    {
        [Fact]
        public async Task GetDealGames_IsSuccess()
        {
            // arrange
            var fixture = new Fixture();
            Mock<IDataProvider> mockDataProvider = new Mock<IDataProvider>();
            var _games = fixture.CreateMany<Game>(10);
            var filter = "";
            mockDataProvider.Setup(x => x.GetGamesAsync(It.IsAny<FilterModel>())).ReturnsAsync(_games).Verifiable();

            var gamesManager = new GamesManager(mockDataProvider.Object);

            // act
            var resulGames = await gamesManager.GetGamesAsync(filter);

            // Assert
            mockDataProvider.Verify(x => x.GetGamesAsync(It.IsAny<FilterModel>()), Times.Once);
            Assert.Equal(_games.First().GameID, resulGames.First().GameID);
            Assert.Equal(_games.Count(), resulGames.Count());
        }

        [Fact]
        public async Task GetDealGames_ThrowsException_UserIsDuplicated()
        {
            // arrange
            var fixture = new Fixture();
            Mock<IDataProvider> mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.Setup(x => x.GetGamesAsync(It.IsAny<FilterModel>())).ThrowsAsync(new Exception("Internal Server Error")).Verifiable();

            var gamesManager = new GamesManager(mockDataProvider.Object);

            var filter = "";

            // act & assert
            await Assert.ThrowsAsync<Exception>(async () => await gamesManager.GetGamesAsync(filter));
        }
    }
}
