using BlazorExpensesTracker.Model;
using BlazorExpensesTracker.UI.Interfaces;
using System.Net.Http;

namespace BlazorExpensesTracker.UI.Services
{
	public class ExpenseService : IExpenseService
	{
		private readonly HttpClient _httpClient;

		public ExpenseService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task DeleteExpense(int id) => await _httpClient.DeleteAsync($"api/expense/{id}");

		public async Task<IEnumerable<Expense>> GetAllExpenses() => await _httpClient.GetFromJsonAsync<IEnumerable<Expense>>($"api/expense");
		
		public async Task<Expense> GetExpenseDetails(int id) => await _httpClient.GetFromJsonAsync<Expense>($"api/expense/{id}");

		public async Task SaveExpense(Expense expense)
		{
			if (expense.Id == 0)
				await _httpClient.PostAsJsonAsync("api/expense", expense);
			else
				await _httpClient.PutAsJsonAsync("api/expense", expense);
		}
	}
}
