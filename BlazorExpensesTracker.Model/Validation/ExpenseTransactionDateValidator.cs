using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpensesTracker.Model.Validation
{
	public class ExpenseTransactionDateValidator : ValidationAttribute
	{
		public int DaysInTheFuture { get; set; }
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime transactionDate;

			if(DateTime.TryParse(value.ToString(), out transactionDate))
			{
				if (transactionDate == DateTime.MinValue)
				{
					return new ValidationResult($"Date shouldn't be empty.",
						new[] { validationContext.MemberName });
				}
				else if (transactionDate > DateTime.Now.AddDays(DaysInTheFuture))
				{
					return new ValidationResult($"Date can't be greater than today plus {DaysInTheFuture}",
						new[] {validationContext.MemberName });
				}
				return null;
			}
			return new ValidationResult("Invalid date.",
				new[] { validationContext.MemberName });
		}

	}
}
