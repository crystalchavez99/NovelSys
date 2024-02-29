using NovelSys.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddControllers();

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();

}



app.UseAuthorization();

app.UseAuthentication();


