using BlazorExpensesTracker.Model.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpensesTracker.Model
{
	public class Expense /*: IValidatableObject*/
	{

		public int Id { get; set; }
		[Required]
		[Range(1,double.MaxValue,ErrorMessage ="Amount needs to be grater than 0")]
		public decimal Amount { get; set; }
		[Required]
		public int CategoryId { get; set; }
		public Category category { get; set; }
		[Required]
		[ExpenseTransactionDateValidator(DaysInTheFuture=30)]
		public DateTime TransactionDate { get; set; }

		public ExpenseType ExpenseType { get; set; }

		public event Action OnSelectedExpenseChanged;

		public void SelectedExpenseChanged(Expense expense)
		{
			Id= expense.Id;
			Amount= expense.Amount;
			CategoryId = expense.CategoryId;
			TransactionDate = expense.TransactionDate;
			ExpenseType = expense.ExpenseType;

			NotifySelectedExpenseChanged();
		}

		private void NotifySelectedExpenseChanged()
		{
			OnSelectedExpenseChanged.Invoke();
		}
		/*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var errors = new List<ValidationResult>();

			if (ExpenseType == ExpenseType.Income && Amount < 0)
			{
				errors.Add(new ValidationResult("Income can't be lesser tha zero.",
				new[] { nameof(Amount) }));
			}
			else if (ExpenseType == ExpenseType.Expense && Amount > 0)
			{
				errors.Add(new ValidationResult("Expenses can't be greater than zero.",
					new[] { nameof(Amount) }));
			}
			return errors;
		}*/
	}
}
