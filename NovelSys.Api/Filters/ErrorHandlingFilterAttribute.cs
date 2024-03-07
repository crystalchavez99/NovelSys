using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NovelSys.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            /*if (context.Exception == null)
             {
                 return;
             }
             context.Result = new ObjectResult(new
             { error = context.Exception.Message });*/
            var exception = context.Exception;
            context.Result = new ObjectResult(exception);
        }
    }
}
