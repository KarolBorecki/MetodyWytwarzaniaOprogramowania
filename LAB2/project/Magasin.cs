using Product;

namespace Magasin
{
    public class Magasin : IMagasin
    {
        private List<IProduct> products;

        public Magasin()
        {
            products = new List<IProduct>();
        }
        public void Add(IProduct product) 
        {
            products.Add(product);

        }

        public bool Delete(int index)
        {
            if(index >= 0 && index < products.Count) {
                products.RemoveAt(index);
                return true;
            }

            return false;
        }

        public bool Update(int index, IProduct data)
        {
            return true;
        }
    }
}