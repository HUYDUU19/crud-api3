using crud_api.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyAppDBContext _dbContext;

        public ProductController(MyAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _dbContext.Products.ToList();
                if (products.Count == 0)
                {
                    return NotFound("Product not available");

                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _dbContext.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product details not found with id {id}");

                }
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
