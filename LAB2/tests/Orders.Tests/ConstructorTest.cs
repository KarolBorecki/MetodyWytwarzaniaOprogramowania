namespace Orders.Tests;

using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders;

public class ConstructorTest
{
    private const string order_json_path = "Data/OrderData.json";

    public static IEnumerable<object[]> ValidOrderTestData()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, order_json_path);
        var json = File.ReadAllText(filePath);
        var jobject = JObject.Parse(json);
        var orders = jobject["order"]?.ToObject<IEnumerable<Order>>();

        foreach (var order in orders ?? Enumerable.Empty<Order>())
        {
            yield return new[] { user };
        }
    }

    [TestMethod]
    [Priority(1)]
    [Owner("Karol Borecki")]
    [TestCategory("Order")]
    [Description("Order should be constructed with valid data")]
    [MemberData(nameof(ValidOrderTestData))]
    public void ConstructingOrder_ForValidDataWithoutStateParameter_ResultsInNewOrderBeeingConstructed(Order order)
    {
        // arrange
        string id = order.GetID();
        string clientID = order.GetClientID();
        IProduct product = order.GetProduct();

        // act 
        var newOrder = new Order(id, clientID, product);

        //assert
        Assert.Equal(id, newOrder.GetID());
        Assert.Equal(clientID, newOrder.GetClientID());
        Assert.Equal(product.GetID(), newOrder.GetProduct().GetID());
        Assert.Equal(state, OrderState.New);
    }
}