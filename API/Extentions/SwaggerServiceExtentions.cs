using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extentions
{
    public static class SwaggerServiceExtentions
    {
        public static IServiceCollection AddSwaggerDocumantation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                       {
                           c.SwaggerDoc("v1", new OpenApiInfo { Title = "Acara API", Version = "v1" });
                           c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                       });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumantation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Acara API v1"));
            return app;
        }
    }
}