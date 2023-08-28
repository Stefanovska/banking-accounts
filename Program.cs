using bank_accounts_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserAccountsService, UserAccountsService>();
builder.Services.AddScoped<IUserAccountTransactionsService, UserAccountTransactionsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

