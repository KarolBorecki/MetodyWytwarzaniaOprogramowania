namespace Core.Tests;

using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

public class PlaceNewOrderTest
{
    [TestMethod]
    [Priority(3)]
    [Owner("Karol Borecki")]
    [TestCategory("PlaceNewOrder")]
    [Description("PlaceNewOrder should add new order to the shop data")]
    public void PlaceNewOrder_ForValidData_ResultsInOrderAdding()
    {
        // arrange
        var shopDataMock = new Mock<IShopData>();
        shopDataMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(new Product("productID", "productName", 1, 1));
        shopDataMock.Setup(x => x.GetClient(It.IsAny<string>())).Returns(new Client("clientID", "clientName", "clientAddress"));
        var shop = new Shop(shopDataMock.Object);

        // act
        shop.PlaceNewOrder("clientID", "productID", 1);

        // assert
        shopDataMock.Verify(x => x.AddOrder(It.IsAny<IClient>(), It.IsAny<IProduct>(), It.IsAny<int>()), Times.Once);
        shop.Verify(x => x.UpdateProduct(It.IsAny<IProduct>(), It.IsAny<int>()), Times.Once);
        shop.GetOrders().Count.Should().Be(1);
    }

    [TestMethod]
    [Priority(2)]
    [Owner("Karol Borecki")]
    [TestCategory("PlaceNewOrder")]
    [Description("PlaceNewOrder should throw exception if product quantity is not enough")]
    [ExpectedException(typeof(ArgumentException))]
    public void PlaceNewOrder_ForFaultyProductID_ResultsInException()
    {
        // arrange
        var shopDataMock = new Mock<IShopData>();
        shopDataMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(null);
        var shop = new Shop(shopDataMock.Object);

        // act
        shop.PlaceNewOrder("clientID", "productID", 1);

        // assert
    }

    [TestMethod]
    [Priority(2)]
    [Owner("Karol Borecki")]
    [TestCategory("PlaceNewOrder")]
    [Description("PlaceNewOrder should throw exception if product quantity is not enough")]
    [ExpectedException(typeof(ArgumentException))]
    public void PlaceNewOrder_ForFaultyClientID_ResultsInException()
    {
        // arrange
        var shopDataMock = new Mock<IShopData>();
        shopDataMock.Setup(x => x.GetClient(It.IsAny<string>())).Returns(null);
        var shop = new Shop(shopDataMock.Object);

        // act
        shop.PlaceNewOrder("clientID", "productID", 1);

        // assert
    }
}