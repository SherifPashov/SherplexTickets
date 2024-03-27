using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Extensions;

namespace SherplexTickets.Attributes
{
    public class MustBeTheaterManagerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ITheaterManagerService? theaterManagerService = context.HttpContext.RequestServices.GetService<ITheaterManagerService>();

            if (theaterManagerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (theaterManagerService != null && theaterManagerService.ExistsТheaterМanagerByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
               context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }

}
