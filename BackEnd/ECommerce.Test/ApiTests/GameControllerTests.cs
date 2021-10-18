using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ECommerce.Api;
using ECommerce.Api.Controllers;
using ECommerce.Api.Models.Common;
using ECommerce.Core.Entities.Interfaces;
using ECommerce.Core.Managers.Interfaces;
using Xunit;
using AutoMapper;
using System.Collections.Generic;
using ECommerce.Core.Entities;

namespace ECommerce.Test
{
    [CollectionDefinition("UserControllerTests", DisableParallelization = true)]
    public class GameControllerTests
    {
        [Fact]
        public async Task GetGames_IsSuccess()
        {
            // arrange
            var fixture = new Fixture();
            Mock<IGamesManager> mockGamesManager = new Mock<IGamesManager>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var _dealGames = fixture.CreateMany<GameDealModel>(10);

            var filter = "";

            mockGamesManager.Setup(x => x.GetGamesAsync(It.IsAny<string>())).ReturnsAsync(_dealGames).Verifiable();
            mockMapper.Setup(x => x.Map<IEnumerable<GameDealModel>>(It.IsAny<IEnumerable<IGame>>())).Returns(_dealGames).Verifiable();

            var dealsController = new DealsController(mockGamesManager.Object, mockMapper.Object);

            // act
            var actionResult = await dealsController.GetGameDeals(filter);

            // Assert
            var resultObject = GetObjectResultContent<IEnumerable<GameDealModel>>(actionResult);
            Assert.NotNull(resultObject);
            Assert.Equal(resultObject.First().gameID, _dealGames.First().gameID);
            Assert.Equal(resultObject.Count(), _dealGames.Count());
        }

        [Fact]
        public async Task GetGames_returnsError_InternalServerError()
        {
            // arrange
            var fixture = new Fixture();
            Mock<IGamesManager> mockGamesManager = new Mock<IGamesManager>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockGamesManager.Setup(x => x.GetGamesAsync(It.IsAny<string>())).Throws(new Exception("Internal server Error")).Verifiable();

            var dealsController = new DealsController(mockGamesManager.Object, mockMapper.Object);

            var filter = "";

            // act
            var actionResult = await dealsController.GetGameDeals(filter);

            // Assert;
            var resultObject = GetObjectResultContent<ResultModel>(actionResult);
            Assert.False(resultObject.IsSuccess);
            Assert.Equal("Internal server Error", resultObject.Errors.First().ToString());
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
