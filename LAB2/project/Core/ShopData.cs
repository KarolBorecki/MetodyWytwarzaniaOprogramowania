using Clients;
using Products;
using Orders;

namespace Core
{
    public class ShopData
    {
        private List<IClient> clients;
        private List<IProduct> products;
        private List<IOrder> orders;

        public ShopData()
        {
            clients = new List<IClient>();
            products = new List<IProduct>();
            orders = new List<IOrder>();
        }

        public void AddClient(IClient client)
        {
            if (clients.Any(client => client.GetID() == client.GetID()))
            {
                throw new ArgumentException("Cannot Add client: Client already exists!");
            }
            clients.Add(client);
        }

        public void AddProduct(IProduct product)
        {
            products.ForEach(product =>
            {
                if (product.GetID() == product.GetID())
                {
                    product.SetQuantity(product.GetQuantity() + product.GetQuantity());
                    return;
                }
            });
            products.Add(product);
        }

        public void AddOrder(IOrder order)
        {
            if (order.GetState() == OrderState.New)
            {
                orders.Add(order);
                order.SetState(OrderState.Approved);
            }
            throw new ArgumentException("Order is already approved by the shop!");
        }


        public void UpdateClient(IClient client)
        {
            if (clients.Any(client => client.GetID() == client.GetID()))
            {
                clients.ForEach(client =>
                {
                    if (client.GetID() == client.GetID())
                    {
                        client.SetName(client.GetName());
                        client.SetSurname(client.GetSurname());
                        client.SetEmail(client.GetEmail());
                        return;
                    }
                });
                return;
            }
            throw new ArgumentException("Cannot Update client: Client does not exist!");
        }

        public void UpdateProduct(IProduct product)
        {
            if (products.Any(product => product.GetID() == product.GetID()))
            {
                products.ForEach(product =>
                {
                    if (product.GetID() == product.GetID())
                    {
                        product.SetName(product.GetName());
                        product.SetPrice(product.GetPrice());
                        product.SetQuantity(product.GetQuantity());
                        return;
                    }
                });
                return;
            }
            throw new ArgumentException("Cannot Update product: Product does not exist!");
        }

        public void UpdateOrder(IOrder order)
        {
            if (ContainsOrder(order.GetID()))
            {
                orders.ForEach(order =>
                {
                    if (order.GetID() == order.GetID())
                    {
                        order.SetProduct(order.GetProduct());
                        order.SetQuantity(order.GetQuantity());
                        order.SetState(order.GetState());
                        return;
                    }
                });
                return;
            }
            throw new ArgumentException("Cannot Update order: Order does not exist!");
        }

        public void RemoveClient(IClient client)
        {
            if (clients.Any(client => client.GetID() == client.GetID()))
            {
                clients.Remove(client);
                return;
            }
            throw new ArgumentException("Cannot Remove client: Client does not exist!");
        }

        public void RemoveProduct(IProduct product)
        {
            if (products.Any(product => product.GetID() == product.GetID()))
            {
                products.Remove(product);
                return;
            }
            throw new ArgumentException("Cannot Remove product: Product does not exist!");
        }

        public void RemoveOrder(IOrder order)
        {
            if (orders.Any(order => order.GetID() == order.GetID()))
            {
                orders.Remove(order);
                return;
            }
            throw new ArgumentException("Cannot Remove order: Order does not exist!");
        }

        public List<IClient> GetClients()
        {
            return clients;
        }

        public List<IProduct> GetProducts()
        {
            return products;
        }

        public List<IOrder> GetOrders()
        {
            return orders;
        }

        public IClient GetClient(string clientID)
        {
            foreach(IClient client in clients)
            {
                if (client.GetID() == clientID)
                {
                    return client;
                }
            }
            return null;
        }

        public IProduct GetProduct(string productID)
        {
            foreach(IProduct product in products)
            {
                if (product.GetID() == productID)
                {
                    return product;
                }
            }
            return null;
        }

        public IOrder GetOrder(string orderID)
        {
            foreach(IOrder order in orders)
            {
                if (order.GetID() == orderID)
                {
                    return order;
                }
            }
            return null;
        }

        public boolean ContainsOrder(string orderID)
        {
            return clients.Any(client => client.GetID() == client.GetID());
        }

    }
}