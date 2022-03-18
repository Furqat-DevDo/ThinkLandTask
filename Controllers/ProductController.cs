using Microsoft.AspNetCore.Mvc;
using ThinkLand.DAL.IConfiguration;
using ThinkLand.Mappers;



namespace ThinkLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitofWork _unitofwork;

        public ProductController(IUnitofWork unitofwork, 
                                ILogger<ProductController> logger)
        {
            _unitofwork = unitofwork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
          => Ok(await _unitofwork.Products.All());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if (await _unitofwork.Products.ExistsAsync(id))
            {
                return Ok(await _unitofwork.Products.GetById(id));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(Model.Product product)
        {
            var pr=product.ToEntity();
            if (await _unitofwork.Products.ExistsAsync(pr.ID))
            {
                return Conflict(nameof(product.Name));
            }

            var result = await _unitofwork.Products.Add(pr);
            await _unitofwork.CompleteAsync();

            if (result.IsSuccess)
            {
                return Ok(result.entity);
            }

            return BadRequest(
            new
            {
                isSuccess = false,
                error = result.Exception.Message
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateAsync(Guid id)
        {
            if (await _unitofwork.Products.ExistsAsync(id))
            {
                return NotFound("Product Not Found !!");
            }
            var product = await _unitofwork.Products.GetById(id);
            var updated = await  _unitofwork.Products.Update(product);
            await _unitofwork.CompleteAsync();
            return Ok(updated);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid iD)
        {
            var res = await _unitofwork.Products.GetById(iD);
            await _unitofwork.Products.Delete(res.ID);
            await _unitofwork.CompleteAsync();
            return Ok();
        }
    }
 
}
