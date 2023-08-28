namespace bank_accounts_api.Models
{
	public class UsersListResponseModel
	{
		public IEnumerable<User>? Users { get; set; }
		public int? Total { get; set; }
		public bool? Error { get; set; }

		public UsersListResponseModel(IEnumerable<User> users, int total)
		{
            Users = users;
			Total = total;
		}

        public UsersListResponseModel(bool error)
        {
            Error = error;
        }
    }
}

