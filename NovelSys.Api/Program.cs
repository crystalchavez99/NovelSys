using NovelSys.Api.Filters;
using NovelSys.Api.Middleware;
using NovelSys.Application;
using NovelSys.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
           .AddApplication()
         .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}



var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();

}



app.UseAuthorization();

app.UseAuthentication();


