using Products;
using Clients;
using Orders;

namespace Orders
{
    public class Order : IOrder
    {
        private string id;
        private string clientID;
        private IProduct product;

        private int quantity;
        private OrderState state;

        public Order(string id, string clientID, IProduct product, OrderState state)
        {
            this.id = id;
            this.clientID = clientID;
            this.product = product;
            this.state = state;
        }

        public Order(string id, string clientID, IProduct product)
        {
            this.id = id;
            this.clientID = clientID;
            this.product = product;
            this.state = OrderState.New;
        }

        public string GetID()
        {
            return this.id;
        }

        public string GetClientID()
        {
            return this.clientID;
        }

        public IProduct GetProduct()
        {
            return this.product;
        }

        public OrderState GetState()
        {
            return this.state;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public void SetProduct(IProduct product)
        {
            this.product = product;
        }

        public void SetState(OrderState state)
        {
            this.state = state;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }
    }
}