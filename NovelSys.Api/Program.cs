using Microsoft.AspNetCore.Mvc.Infrastructure;
using NovelSys.Api.Filters;
using NovelSys.Api.Middleware;
using NovelSys.Application;
using NovelSys.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
          .AddApplication()
         .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}



var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}



app.UseAuthorization();

app.UseAuthentication();


