namespace Products 
{
    public interface IProduct 
    {
        public string GetID();
        public string GetName();
        public int GetPrice();
        public int GetQuantity();

        public void SetName(string name);

        public void SetPrice(int price);

        public void SetQuantity(int quantity);
    }
}