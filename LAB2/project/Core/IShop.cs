using Orders;

namespace Core
{
    public interface IShop 
    {
        public void PlaceNewOrder(string clientID, string productID, int quantity);
        public void UpdateOrderStatus(string orderID, OrderState state);
        public void CancelAnOrder(string orderID);

        public List<IClient> GetClients();
        public List<IOrder> GetOrders();
        public List<IProduct> GetProducts();
    }
}