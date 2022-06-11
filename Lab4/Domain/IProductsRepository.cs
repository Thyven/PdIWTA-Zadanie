using System;

namespace Lab4
{
    public interface IProductsRepository
    {
        Product GetById(Guid id);
        List<Product> GetAll();
        public Product Add(Product product);
        Product Save(Product product);
        Product Update(Product product);
        void DeleteByName(string name);
    }
}
