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
	public class CategoryRepository : ICategoryRepository
	{
		private SqlConfiguration _connectionString;

		public CategoryRepository(SqlConfiguration connectionString)
		{
			_connectionString = connectionString;
		}

		protected SqlConnection dbConnection()
		{
			return new SqlConnection(_connectionString.ConnectionString);
		}
		public async Task<bool> DeleteCategory(int id)
		{
			var db = dbConnection();
			var sql = @"DELETE FROM Categories
						WHERE Id = @Id";
			var result = await db.ExecuteAsync(sql, new { Id = id });
			return result > 0;
		}

		public async Task<IEnumerable<Category>> GetAllCategories()
		{
			var db = dbConnection();
			var sql = @"SELECT *
						FROM Categories";
			var enpe = await db.QueryAsync<Category>(sql,new { });
			return enpe;
		}

		public async Task<Category> GetCategoryDetails(int id)
		{
			var db = dbConnection();
			var sql = @"SELECT Id, Name
						FROM Categories
						WHERE Id=@Id";
			return await db.QueryFirstOrDefaultAsync<Category>(sql, new { Id= id });
		}

		public async Task<bool> InsertCategory(Category category)
		{
			var db = dbConnection();
			var sql = @"INSERT INTO Categories(Name)
						VALUES(@Name)";
			var result = await db.ExecuteAsync(sql, new { category.Name });
			return result > 0;
		}

		public async Task<bool> UpdateCategory(Category category)
		{
			var db = dbConnection();
			var sql = @"UPDATE Categories
						SET Name = @Name
						WHERE Id = @Id";
			var result = await db.ExecuteAsync(sql, new { category.Name, category.Id});
			return result > 0;
		}
	}
}
