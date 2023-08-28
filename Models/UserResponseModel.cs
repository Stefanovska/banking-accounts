namespace bank_accounts_api.Models
{
	public class UserResponseModel
	{
		public User? User { get; set; }
		public bool? Error { get; set; }

		public UserResponseModel(User user, bool error)
		{
			User = user;
			Error = error;
		}
	}
}

