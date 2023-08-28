using Microsoft.AspNetCore.Mvc;
using System.Net;
using bank_accounts_api.Models;
using bank_accounts_api.Services;

namespace bank_accounts_api.Controllers;

[ApiController]
[Route("users/{userId}/accounts")]
public class UserAccountsController : ControllerBase
{
    private readonly IUserAccountsService _userAccountsService;
    private readonly IUsersService _usersService;

    public UserAccountsController(IUserAccountsService userAccountsService, IUsersService usersService)
    {
        _userAccountsService = userAccountsService;
        _usersService = usersService;
    }

    [HttpGet]
    public dynamic Get(string userId)
    {
        try
        {
            return _userAccountsService.GetAccounts(userId);
        }
        catch (Exception ex)
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }

    [HttpPost]
    public UserResponseModel Create([Bind("InitialCredit")] UserAccount userAccount, string userId)
    {
        try
        {
            _userAccountsService.AddAccount(userAccount, userId);
            User user = _usersService.GetUser(userId);
            return new UserResponseModel(user, false);
        } catch (Exception ex)
        {
            return new UserResponseModel(null, true);
        }
    }
}