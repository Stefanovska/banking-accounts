using bank_accounts_api.Models;

namespace bank_accounts_api.Services
{
    public interface IUsersService
    {
        User AddUser(User user);
        List<User> GetUsers();
    }
}

