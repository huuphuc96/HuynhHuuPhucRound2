using FilmManagement.Core.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FilmManagement.Infrastructure.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddAppSwagger(this IServiceCollection services)
        {
            var groups = GetSwaggerGroups();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(e =>
                    $"{e.ActionDescriptor.RouteValues["action"]}"
                );
                foreach (var group in groups)
                {
                    c.SwaggerDoc(group, new OpenApiInfo
                    {
                        Title = $"API for {group.Replace("_", " ")}",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Big Star Theater",
                            Email = "bigstar@gmail.com",
                            Url = new Uri("https://logixtek.com/")
                        }
                    });
                }

                c.DocInclusionPredicate((docName, apiDes) =>
                {
                    return docName == apiDes.GroupName;
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        public static void UseAppSwagger(this IApplicationBuilder app)
        {
            var groups = GetSwaggerGroups();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                foreach (var group in groups)
                {
                    c.SwaggerEndpoint($"/swagger/{group}/swagger.json", group);
                }
                c.DocExpansion(DocExpansion.None);
                //c.RoutePrefix = "api-document";
            });
        }

        private static IEnumerable<string> GetSwaggerGroups()
        {
            var groups = new SwaggerGroup().GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.FieldType == typeof(string))
                .Select(x => x.GetValue(null).ToString());
            return groups;
        }
    }
}
