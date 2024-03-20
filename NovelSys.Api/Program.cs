using NovelSys.Api;
using NovelSys.Application;
using NovelSys.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
           .AddPresentation()
          .AddApplication()
          .AddInfrastructure(builder.Configuration);
}



var app = builder.Build();
{
    // request goes through these pipelines
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}



//app.UseAuthorization();

//app.UseAuthentication();


