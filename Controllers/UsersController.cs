using Microsoft.AspNetCore.Mvc;
using System.Net;
using bank_accounts_api.Models;
using bank_accounts_api.Services;

namespace bank_accounts_api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public UsersListResponseModel Get()
    {
        try
        {
            IEnumerable<User> users = _usersService.GetUsers();
            return new UsersListResponseModel(users, users.Count());
        } catch(Exception ex)
        {
            return new UsersListResponseModel(true);
        }
    }

    [HttpGet]
    [Route("{userId}")]
    public UserResponseModel GetDetails(string userId)
    {
        try
        {
            User user = _usersService.GetUser(userId);
            return new UserResponseModel(user, false);
        } catch (Exception ex)
        {
            return new UserResponseModel(null, true);
        }
    }

    [HttpPost]
    public UserResponseModel Create([Bind("Name,Surname,Balance")] User user)
    {
        if (ModelState.IsValid)
        {
            _usersService.AddUser(user);
            return new UserResponseModel(user, false);
        }
        else
        {
            return new UserResponseModel(null, true);
        }
    }
}