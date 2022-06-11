using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.NewGuid(), "111", true),
            new Product(Guid.NewGuid(), "222", true),
            new Product(Guid.NewGuid(), "333", true)
        };

        public ProductsInMemoryRepository()
        {
        }
        public Product Add(Product product)
        {
            var existsProduct = _products.SingleOrDefault(x => x.Id == product.Id);
            if (existsProduct != null)
                throw new Exception($"Product with id: {product.Id} is exosts!");
            else
            {
                _products.Add(product);
            }

            return product;
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(Guid id)
        {
            return _products.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Product Save(Product product)
        {
            _products.Add(product);
            return product;
        }
        public Product Update(Product product)
        {
           var uID =  _products.FindIndex(x => x.Id.Equals(product.Id));
            _products[uID] = product;
            return product;
        }

        public void DeleteByName(string name)
        {

            Product _product = _products.FirstOrDefault(x => x.Name.Equals(name));
            _products.Remove(_product);

        }


    }
}
