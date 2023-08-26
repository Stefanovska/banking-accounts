using System;
namespace bank_accounts_api.Models
{
	public class Transaction
	{
		public Amount? Amount { get; set; }

		public Transaction(Amount amount)
		{
			Amount = amount;
		}
	}
}

