namespace bank_accounts_api.Models
{
    public class UserAccount
    {
        public string Id { get; set; }
        public string? CustomerId { get; set; }
        public Amount InitialCredit { get; set; }
        public bool IsCurrent { get; set; }

        public UserAccount(string customerId, Amount initialCredit, bool isCurrent)
        {
            Id = Guid.NewGuid().ToString();
            CustomerId = customerId;
            InitialCredit = initialCredit;
            IsCurrent = isCurrent;
        }
    }
}

