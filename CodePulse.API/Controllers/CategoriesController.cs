using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetCategories()
        {
            // Replace with actual logic to retrieve categories
            var categories = new List<string> { "Category1", "Category2" };
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetCategory(int id)
        {
            // Replace with actual logic to retrieve a category by id
            var category = "Category" + id;
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO request)
        {

            var category = new Category
            { Name = request.Name, UrlHandle = request.UrlHandle };
            
            await categoryRepository.CreateAsync(category);   

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            
            return Ok(response);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            // Replace with actual logic to delete a category by id
            var category = "Category" + id;
            if (category == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
