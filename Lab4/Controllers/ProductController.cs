using Lab4.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    [ApiController]
    [Route ("[controller]")]

    public class ProductController : Controller
    {
        IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> Get()
        {
            return productsRepository.GetAll();
        }

        [HttpGet("PostProducts")]
        public Product Post(Product product)
        {
            return productsRepository.GetById(product.Id);
        }

        [HttpPost("AddProduct")]
        public Product Save(AddProductDTO product)
        {
            var p = new Product(product.Id, product.Name, product.IsAvailable);
            return productsRepository.Save(p);
        }

        [HttpPost("UpdateProducts")]
        public Product Update(UpdateProductDTO updateproduct)
        {
            var p = new Product(updateproduct.Id, updateproduct.Name, updateproduct.IsAvailable);
            return productsRepository.Update(p);
        }

        [HttpDelete]
        public void  DeleteByName(string name)
        {
            productsRepository.DeleteByName(name);
        }

    }
}
