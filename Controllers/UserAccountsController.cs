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

    public UserAccountsController(IUserAccountsService userAccountsService)
    {
        _userAccountsService = userAccountsService;
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
    public HttpResponseMessage Create([Bind("InitialCredit")] UserAccount userAccount, string userId)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _userAccountsService.AddAccount(userAccount, userId);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        } catch (Exception ex)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}