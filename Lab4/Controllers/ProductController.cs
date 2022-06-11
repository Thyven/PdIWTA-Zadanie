using Lab4.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Post(Product product)
        {
            var produt = new Product(product.Id, product.Name, product.IsAvailable);
            return Ok(productsRepository.Add(produt));

        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> Get()
        {
            return productsRepository.GetAll();
        }

        [HttpGet("PostProducts")]
        public Product Get(Guid product)
        {
            return productsRepository.GetById(product);
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