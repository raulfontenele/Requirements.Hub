using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Requirements.Hub.Exceptions.ExceptionsBase;

namespace Requirements.Hub.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is RequirementHubException) 
            {
                var reqException = (RequirementHubException)context.Exception;

                context.HttpContext.Response.StatusCode = (int)reqException.GetStatusCode();
                context.Result = new ObjectResult(context.Exception.Message);
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult("Erro desconhecido");
            }
        }
    }
}
