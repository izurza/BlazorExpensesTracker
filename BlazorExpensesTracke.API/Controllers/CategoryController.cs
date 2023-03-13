using BlazorExpensesTracker.Data.Repositories;
using BlazorExpensesTracker.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExpensesTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			return Ok(await _categoryRepository.GetAllCategories());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryDetails(int id)
		{
			return Ok(await _categoryRepository.GetCategoryDetails(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromBody] Category category)
		{
			if (category == null)
			{
				return BadRequest();
			}
			if (category.Name == string.Empty)
			{
				ModelState.AddModelError("Name", "Category name shouldn't be empty");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			
			var created = await _categoryRepository.InsertCategory(category);
			return Created("created", created);
			
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory([FromBody] Category category)
		{
			if (category == null)
			{
				return BadRequest();
			}
			if (category.Name.Trim() == string.Empty)
			{
				ModelState.AddModelError("Name", "Category name shouldn;t be empty");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _categoryRepository.UpdateCategory(category);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			if (id == 0) 
				return BadRequest();
			
			await _categoryRepository.DeleteCategory(id);

			return NoContent();
		}
		
		protected IActionResult Index()
		{
			return View();
		}
	}
}
