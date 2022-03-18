using Microsoft.AspNetCore.Mvc;
using ThinkLand.DAL.IConfiguration;
using ThinkLand.Mappers;



namespace ThinkLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IUnitofWork _unitofwork;

        public CategoryController(IUnitofWork unitofwork,
                                ILogger<CategoryController> logger)
        {
            _unitofwork = unitofwork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
          => Ok(await _unitofwork.Categories.All());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if (await _unitofwork.Categories.ExistsAsync(id))
            {
                return Ok(await _unitofwork.Categories.GetById(id));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(Model.Category Category)
        {
            var pr = Category.ToEntity();
            if (await _unitofwork.Categories.ExistsAsync(pr.ID))
            {
                return Conflict(nameof(Category.Name));
            }

            var result = await _unitofwork.Categories.Add(pr);
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
        public async Task<IActionResult> UpdateAsync(Guid id)
        {
            if (await _unitofwork.Categories.ExistsAsync(id))
            {
                return NotFound("Category Not Found !!");
            }
            var Category = await _unitofwork.Categories.GetById(id);
            var updated = await _unitofwork.Categories.Update(Category);
            await _unitofwork.CompleteAsync();
            return Ok(updated);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid iD)
        {
            var res = await _unitofwork.Categories.GetById(iD);
            await _unitofwork.Categories.Delete(res.ID);
            await _unitofwork.CompleteAsync();
            return Ok();
        }
    }

}
