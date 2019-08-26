namespace venticuatrosiete.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using venticuatrosiete.Web.Data;

    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return this.Ok(_productRepository.GetAll());
        }

    }
}
