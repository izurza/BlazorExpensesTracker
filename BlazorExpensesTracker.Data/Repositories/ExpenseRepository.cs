using BlazorExpensesTracker.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpensesTracker.Data.Repositories
{
	public	class ExpenseRepository : IExpenseRepository
	{

		private SqlConfiguration _connectionString;

		public ExpenseRepository(SqlConfiguration connectionString)
		{
			_connectionString = connectionString;
		}

		protected SqlConnection dbConnection()
		{
			return new SqlConnection(_connectionString.ConnectionString);
		}
		public async Task<bool> DeleteExpense(int id)
		{
			var db =dbConnection();
			var sql = @"DELETE Expenses WHERE Id=@Id";
			var result = await db.ExecuteAsync(sql,new {Id = id});
			return result > 0;
		}

		public async Task<IEnumerable<Expense>> GetAllExpenses()
		{
			var db = dbConnection();
			var sql = @"SELECT e.Id, Amount, CategoryId, ExpenseType, TransactionDate,
						c.Id, c.Name
						FROM Expenses e
						INNER JOIN Categories c ON e.CategoryId = c.Id";
			var result = await db.QueryAsync<Expense,Category, Expense>(sql,
				((expense, category) =>
				{
					expense.category = category;
					return expense;
				}),new { }, splitOn:"Id");
			return result;
		}

		public async Task<Expense> GetExpenseDetails(int id)
		{
			var db = dbConnection();
			var sql = @"SELECT e.Id, e.Amount, e.CategoryId, e.ExpenseType, e.TransactionDate,
						c.Name
						FROM Expenses e
						INNER JOIN Categories c ON e.CategoryId = c.Id
						WHERE e.Id = @Id";
			var result = await db.QueryFirstOrDefaultAsync<Expense>(sql,new {Id= id });
			return result;
		}

		public async Task<bool> InsertExpense(Expense expense)
		{
			var db = dbConnection();
			var sql = @"INSERT INTO Expenses(Amount, CategoryId, ExpenseType, TransactionDate)
						VALUES(@Amount, @CategoryId, @ExpenseType, @TransactionDate)";
			var result = await db.ExecuteAsync(sql,
				new { expense.Amount, expense.CategoryId, expense.ExpenseType, expense.TransactionDate });
			return result > 0;
		}
		public async Task<bool> UpdateExpense(Expense expense)
		{
				var db = dbConnection();
				var sql = @"UPDATE Expenses
							SET Amount=@Amount, CategoryId=@CategoryId, ExpenseType=@ExpenseType, TransactionDate=@TransactionDate
							WHERE ID=@Id";
				var result = await db.ExecuteAsync(sql, 
					new { expense.Id, expense.Amount, expense.CategoryId, expense.ExpenseType, expense.TransactionDate });
				return result>0;
		}
	

	}
}
