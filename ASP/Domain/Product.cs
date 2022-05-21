using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    public class Product
    {
        public Product()
        {

        }

        public Product(Guid id, string name, bool isAvailable)
        {
            Id = id;
            Name = name;
            IsAvailable = isAvailable;
        }

        public Guid Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }

  

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
