﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Caching.Memory;
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
    public IEnumerable<User> Get()
    {
        return _usersService.GetUsers();
    }

    [HttpPost]
    public HttpResponseMessage Create([Bind("Name,Surname,Balance")] User user)
    {
        if (ModelState.IsValid)
        {
            _usersService.AddUser(user);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        else
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}