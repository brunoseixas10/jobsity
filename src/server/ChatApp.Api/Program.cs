using ChatApp.Api;
using ChatApp.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddSignalR();
var app = builder.Build();
app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:5135"));
app.MapHub<ChatHub>("/chat");

// Configure the HTTP request pipeline.



app.MapPost("/users/add", (User user) =>
{
    var validatorResult = user.Validate();
    if (!validatorResult) return Results.BadRequest();

    var result = DatabaseMock.AddUser(user);

    if (!result) return Results.BadRequest();

    return Results.Ok();
});

app.MapPost("/login", (User user) =>
{
    var validatorResult = user.Validate();
    if (!validatorResult) return Results.BadRequest();

    var result = DatabaseMock.LogIn(user);

    if (!result) return Results.BadRequest();

    return Results.Ok();
});


app.Run();