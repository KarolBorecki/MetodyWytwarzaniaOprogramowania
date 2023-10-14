namespace Core.Tests;

using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

public class UpdateOrderStatusTest
{
    [TestMethod]
    [Priority(3)]
    [Owner("Karol Borecki")]
    [TestCategory("UpdateOrderStatus")]
    [Description("UpdateOrderStatus should update order in the shop data")]
    [InlineData(OrderState.Pending)]
    [InlineData(OrderState.Completed)]
    [InlineData(OrderState.Cancelled)]
    public void UpadteOrderStatus_ForValidOrerID_ResultsInUpdatingAnOrder(OrderState state)
    {
        // arrange
        var shopDataMock = new Mock<IShopData>();
        shopDataMock
        .Setup(x => x.GetOrder(It.IsAny<string>()))
        .Returns(
            new Order("orderID", new Client("clientID", "clientName", "clientAddress"),
            new Product("productID", "productName", 1, 1),
            1,
            OrderState.New));
        shopDataMock
        .Setup(x => x.UpdateOrder(It.IsAny<IOrder>(), It.IsAny<OrderState>()))
        .Callback((IOrder order) => {
            order.SetState(state);
        }).Verifiable();;

        var shop = new Shop(shopDataMock.Object);

        // act
        shop.UpdateOrderStatus("orderID", state);

        // assert
        shop.GetOrder("orderID").GetState().Should().Be(state);
    }

    [TestMethod]
    [Priority(2)]
    [Owner("Karol Borecki")]
    [TestCategory("UpdateOrderStatus")]
    [Description("UpdateOrderStatus to other than approved should throw exception if order is new")]
    [ExpectedException(typeof(ArgumentException))]
    [InlineData(OrderState.Pending)]
    [InlineData(OrderState.Completed)]
    [InlineData(OrderState.Cancelled)]
    public void UpadteOrderStatus_ForNotAcceptedOrder_ToPendding_ResultsInException(OrderState state)
    {
        // arrange
        var shopDataMock = new Mock<IShopData>();
        shopDataMock
        .Setup(x => x.GetOrder(It.IsAny<string>()))
        .Returns(
            new Order("orderID", new Client("clientID", "clientName", "clientAddress"),
            new Product("productID", "productName", 1, 1),
            1,
            OrderState.New));

        var shop = new Shop(shopDataMock.Object);

        // act
        shop.UpdateOrderStatus("orderID", state);

        // assert
    }
}