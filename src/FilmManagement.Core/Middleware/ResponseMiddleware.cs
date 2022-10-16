using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Core.Middleware
{
    public class ResponseMiddleware
    {
        public class ResponseClass
        {
            public int count { get; set; }

            public DateTime timestamp { get; set; }

            public string status { get; set; }

            public object results { get; set; }
            public string ErrorMessage { get; set; }
        }
        private readonly RequestDelegate _next;
        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (IsSwagger(context))
                await this._next(context);
            else
            {
                var existingBody = context.Response.Body;
                using (var newBody = new MemoryStream())
                {
                    context.Response.Body = newBody;
                    await _next(context);
                    var newResponse = await FormatResponse(context.Response);
                    context.Response.Body = new MemoryStream();
                    newBody.Seek(0, SeekOrigin.Begin);
                    context.Response.Body = existingBody;
                    var newContent = JsonConvert.DeserializeObject(new StreamReader(newBody).ReadToEnd());

                    // Send modified content to the response body.
                    //
                    await context.Response.WriteAsync(newResponse);
                }
            }

        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }
        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...and copy it into a string...I'D LIKE TO SEE A BETTER WAY TO DO THIS
            //
            response.Body.Seek(0, SeekOrigin.Begin);
            var content = await new StreamReader(response.Body).ReadToEndAsync();
            var Response = new ResponseClass();
            Response.status = response.StatusCode == 200 ? "success" : "error";
            if (!IsResponseValid(response))
            {
                Response.ErrorMessage = content;
            }
            else
            {
                Response.results = content;
            }
            Response.count = response.ToString().Length;
            var json = JsonConvert.SerializeObject(Response);

            //We need to reset the reader for the response so that the client an read it
            response.Body.Seek(0, SeekOrigin.Begin);
            return $"{json}";
        }

        private bool IsResponseValid(HttpResponse response)
        {
            if ((response != null)
                && (response.StatusCode == 200
                || response.StatusCode == 201
                || response.StatusCode == 202))
            {
                return true;
            }
            return false;
        }
    }
}
