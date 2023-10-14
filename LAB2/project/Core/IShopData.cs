using Clients;
using Products;
using Orders;

namespace Core
{
    public interface IShopData
    {
        public void AddClient(IClient client);
        public void AddProduct(IProduct product);
        public void AddOrder(IClient client, IProduct product, int quantity);

        public void UpdateClient(IClient client);
        public void UpdateOrder(IOrder order, OrderState state);
        public void UpdateProduct(IProduct product, int quantity);

        public void RemoveClient(IClient client);
        public void RemoveProduct(IProduct product);
        public void RemoveOrder(IOrder order);

        public List<IClient> GetClients();
        public List<IProduct> GetProducts();
        public List<IOrder> GetOrders();

        public IClient GetClient(string clientID);
        public IProduct GetProduct(string productID);
        public IOrder GetOrder(string orderID);

        public boolean ContainsOrder(string orderID);
    }
}