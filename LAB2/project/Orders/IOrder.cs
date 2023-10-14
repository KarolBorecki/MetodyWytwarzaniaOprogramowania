using Orders;
using Products;

namespace Orders
{
    public enum OrderState
    {
        New,
        Approved,
        Pending,
        Completed,
        Cancelled
    }
    public interface IOrder
    {
        public string GetID();
        public string GetClientID();
        public IProduct GetProduct();
        public OrderState GetState();
        public int GetQuantity();

        public void SetProduct(IProduct product);
        public void SetState(OrderState state);
        public void SetQuantity(int quantity);


    }
}