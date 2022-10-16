using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagement.API.Extensions
{
    /// <summary>
    /// ModelState extensions
    /// </summary>
    public static class ModelStateExtensions
    {
        /// <summary>
        /// Get error message from model state
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetErrorMessages(this ModelStateDictionary modelState)
        {
            var errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => string.IsNullOrEmpty(x.ErrorMessage) ? x.Exception?.Message : x.ErrorMessage);
            return errors;
        }
    }
}