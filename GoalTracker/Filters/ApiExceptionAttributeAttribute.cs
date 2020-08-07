using GoalTracker.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoalTracker.Web.Filters
{
    public class ApiExceptionAttributeAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var baseException = context.Exception.GetBaseException();

            int statusCode = StatusCodes.Status500InternalServerError;
            string statusMessage = "დაფიქსირდა სისტემური შეცდომა";

            BaseApiException baseApiException = null;
            if (baseException is BaseApiException)
            {
                baseApiException = ((BaseApiException)baseException);
                statusCode = baseApiException.ResponseHttpStatusCode;
                statusMessage = baseApiException.BackEndMessage;
            }

            context.HttpContext.Response.StatusCode = statusCode;

            context.Result = new JsonResult(new
            {
                statusCode = statusCode,
                error = statusMessage,
            });

            base.OnException(context);
        }
    }
}
