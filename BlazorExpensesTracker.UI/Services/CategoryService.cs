using BlazorExpensesTracker.Model;
using BlazorExpensesTracker.UI.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System;
using System.Linq;
using System.ComponentModel;

namespace BlazorExpensesTracker.UI.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _httpClient;

		public CategoryService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task DeleteCategory(int id) =>await _httpClient.DeleteAsync($"api/category/{id}");
		public async Task<IEnumerable<Category>> GetAllCategories()=> await _httpClient.GetFromJsonAsync<IEnumerable<Category>>($"api/category");
		public async Task<Category> GetCategoryDetails(int id) => await _httpClient.GetFromJsonAsync<Category>($"api/category/{id}");
		public async Task SaveCategory(Category category) 
		{ 
			if (category.Id == 0)
				await _httpClient.PostAsJsonAsync("api/category", category);
			else
				await _httpClient.PutAsJsonAsync("api/category", category);
		}
	}
}
