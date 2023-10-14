using Clients;
using Products;
using Orders;

namespace Core
{
    public class Shop : IShop
    {
        private IShopData shopData;

        public Shop(IShopData shopData)
        {
            this.shopData = shopData;
        }

        public void PlaceNewOrder(string clientID, string productID, int quantity)
        {
            IClient client = shopData.GetClient(clientID);
            IProduct product = shopData.GetProduct(productID);
            if (client == null)
            {
                throw new System.ArgumentException("Client not found");
            }
            if (product == null)
            {
                throw new System.ArgumentException("Product not found");
            }
            if (product.GetQuantity() < quantity)
            {
                throw new System.ArgumentException("Not enough products in stock");
            }
            shopData.AddOrder(client, product, quantity);
            shopData.UpdateProduct(product, product.GetQuantity() - quantity);
        }

        public void UpdateOrderStatus(string orderID, OrderState state)
        {
            IOrder order = shopData.GetOrder(orderID);
            if (order == null)
            {
                throw new System.ArgumentException("Order not found");
            }
            if (order.GetState() == OrderState.New && state != OrderState.Approved)
            {
                throw new System.ArgumentException("Order is not approved");
            }
            shopData.UpdateOrder(order, state);
        }

        public void CancelAnOrder(string orderID)
        {
            IOrder order = shopData.GetOrder(orderID);
            if (order == null)
            {
                throw new System.ArgumentException("Order not found");
            }
            shopData.UpdateOrder(order, OrderState.Cancelled);
            shopData.UpdateProduct(order.GetProduct(), order.GetProduct().GetQuantity() + order.GetQuantity());
        }

        public List<IClient> GetClients()
        {
            return shopData.GetClients();
        }

        public List<IOrder> GetOrders()
        {
            return shopData.GetOrders();
        }

        public List<IProduct> GetProducts()
        {
            return shopData.GetProducts();
        }
    }
}