namespace Products
{
    public class Product : IProduct
    {
        private string id;
        private string name;
        private int price;
        private int quantity;

        public Product(string id, string name, int price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public string GetID()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
        public int GetPrice()
        {
            return price;
        }
        public int GetQuantity()
        {
            return quantity;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPrice(int price)
        {
            this.price = price;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }
    }
}