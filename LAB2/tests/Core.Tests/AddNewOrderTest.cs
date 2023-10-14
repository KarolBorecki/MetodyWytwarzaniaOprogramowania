namespace Core.Tests;

using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Orders;

public class AddNewOrderTest
{
    [TestMethod]
    [Priority(3)]
    [Owner("Karol Borecki")]
    [TestCategory("AddNewOrder")]
    [Description("AddNewOrder should add new order to the shop data")]
    public void AddNewOrder_ForValidNewOrderData_ResultsInNewOrderBeingAdded()
    {
        // arrange
        var shopData = new ShopData();
        var newOrder = new Order("order id", "client id", new Product("product id", "product name", 10, 10), OrderState.New);

        // act
        shopData.AddNewOrder(newOrder);

        // assert
        var addedOrder = shopData.GetOrder("order id");
        Assert.Equal(newOrder.GetID(), addedOrder.GetID());
        Assert.Equal(newOrder.GetClientID(), addedOrder.GetClientID());
        Assert.Equal(newOrder.GetProduct().GetID(), addedOrder.GetProduct().GetID());
        Assert.Equal(OrderState.Approved, addedOrder.GetState());
    }
}