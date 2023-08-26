using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Caching.Memory;
using bank_accounts_api.Models;

namespace bank_accounts_api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<WeatherForecastController> _logger;

    public UsersController(IMemoryCache memoryCache, ILogger<WeatherForecastController> logger)
    {
        _memoryCache = memoryCache;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return (List<User>)_memoryCache.Get(Utils.Constants.USERS_KEY);
    }

    [HttpPost]
    public HttpResponseMessage Create([Bind("Name,Surname,Balance")] User user)
    {
        if (ModelState.IsValid)
        {
            List<User> users = (List<User>)_memoryCache.Get(Utils.Constants.USERS_KEY);
            if (users != null)
            {
                users.Add(user);
                _memoryCache.Set(Utils.Constants.USERS_KEY, users);
            } else
            {
                List<User> newUsersList = new()
                {
                    user
                };
                _memoryCache.Set(Utils.Constants.USERS_KEY, newUsersList);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        else
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}