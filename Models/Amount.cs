namespace bank_accounts_api.Models
{
    public class Amount
    {
        public float Value { get; set; }
        public string Currency { get; set; }

        public Amount(float value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}
