using FilmManagement.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace FilmManagement.API.Common
{
    /// <summary>
    /// Base controller
    /// </summary>
    [ApiController]
    [Authorize]
    public class BaseApiController : Controller
    {
        /// <summary>
        /// current logged in userid
        /// </summary>
        protected string CurrentUserId => User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        /// <summary>
        /// Override OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.GetErrorMessages();
                throw new ArgumentException(errors.FirstOrDefault());
            }
            base.OnActionExecuting(context);
        }
    }
}
