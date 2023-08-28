using bank_accounts_api.Models;

namespace bank_accounts_api.Utils
{
	public static class MemoryStorageUtility
	{
        public static List<User> Users { get; set; } = new();
	}
}

