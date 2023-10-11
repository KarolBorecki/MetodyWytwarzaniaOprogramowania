using Product.IProduct;

namespace Magasin
{
    public interface IMagasin
    {
        public void Add(IProduct product);
        public bool Delete(int index);

        public bool Update(int index, IProduct data);
    }
}