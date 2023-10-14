namespace Core.Tests;

using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

public class UpdateOrderStatusTest
{
    public TestContext TestContext { get; set; }

    public static IEnumerable<object[]> Orders
    {
        get
        {
            yield return new object[] { new Order("order1", "client1", new Product("product1", "product1", 10, 20), OrderState.New) };
            yield return new object[] { new Order("order2", "client2", new Product("product2", "product2", 2, 54), OrderState.New) };
        }
    }

    [TestMethod]
    [Priority(3)]
    [Owner("Karol Borecki")]
    [TestCategory("UpdateOrder")]
    [Description("UpdateOrder should update order in the shop data")]
    [MemberData(nameof(Orders))]
    public void UpadteOrder_ForGivenOrderData_ResultsInCorrectOrderUpdate(Order order)
    {
        // arrange
        TestContext.WriteLine("Order: {0}", order.GetID());
         var shopDataMock = new Mock<IShopData>();
        shopDataMock.Setup(x => x.ContainsOrder(It.IsAny<string>())).Returns(true);

        // act
        shopDataMock.UpdateOrder(order);

        // assert
        shopDataMock.GetOrder("orderID").GetState().Should().Be(order.GetState());  
        shopDataMock.GetOrder("orderID").GetQuantity().Should().Be(order.GetQuantity());
        shopDataMock.GetOrder("orderID").GetProduct().GetID().Should().Be(order.GetProduct().GetID());
    }
}