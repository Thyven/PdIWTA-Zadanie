using System;

namespace Lab4
{
    public interface IProductsRepository
    {
        Product GetById(Guid id);
        List<Product> GetAll();
        Product Save(Product product);
        Product Update(Product product);
        void DeleteByName(string name);
    }
}
