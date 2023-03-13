using BlazorExpensesTracker.Model;

namespace BlazorExpensesTracker.UI.Interfaces
{
	public interface IExpenseService
	{
		Task<IEnumerable<Expense>> GetAllExpenses();
		Task<Expense> GetExpenseDetails(int id);
		Task SaveExpense(Expense expense);
		Task DeleteExpense(int id);
	}
}
