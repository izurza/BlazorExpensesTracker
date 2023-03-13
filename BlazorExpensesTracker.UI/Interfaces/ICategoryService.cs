using BlazorExpensesTracker.Model;

namespace BlazorExpensesTracker.UI.Interfaces
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAllCategories();
		Task<Category> GetCategoryDetails(int id);
		Task SaveCategory(Category category);
		Task DeleteCategory(int id);
	}
}
