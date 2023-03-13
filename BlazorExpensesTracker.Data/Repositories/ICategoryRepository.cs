using BlazorExpensesTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpensesTracker.Data.Repositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllCategories();
		Task<Category> GetCategoryDetails(int id);
		Task<bool> InsertCategory(Category category);
		Task<bool> UpdateCategory(Category category);
		Task<bool> DeleteCategory(int id);
	}
}
