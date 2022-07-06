using ChannelEngine.BusinessService;
using ChannelEngine.BusinessService.Interface;
using ChannelEngine.UnitTest.MockObjects;
using Moq;
using Xunit;

namespace ChannelEngine.UnitTest
{
    public class InProgressServiceUnitTest //: IClassFixture<InProgressService<Startup>>
    {
        [Fact]
        public void Test1()
        {
            var mockIOrderService = new MockIOrderService().GetAllOrdersByStatus(Shared.Enumerations.OrderStatusEnum.IN_PROGRESS);
            var mockIProductService = new Mock<IProductService>();



            //Arrange - Setup the mock IsValid method
            //var mockLeagueRepo = new MockLeagueRepository().MockIsValid(false);

            //Create the Service instance
            var inProgressService = new InProgressService(new MockIOrderService().Object, mockIProductService.Object);

            //Act - Call the method being tested
            var allPlayers = inProgressService.GetInProgressForTop5SellingProducts();

            //Assert
            //First, assert that the player list returned is empty.
            Assert.Empty(allPlayers);
            //Also assert that IsValid was called exactly once.
           // mockLeagueRepo.VerifyIsValid(Times.Once());
        }
    }
}