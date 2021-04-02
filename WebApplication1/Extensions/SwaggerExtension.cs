using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;


namespace Builders.View.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddConfigurationSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Power BI",
                    Description = "Sistema para mostrar os gráficos em Power BI",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Diogo Ferreira",
                        Email = string.Empty,
                        Url = new Uri("https://about.me/diogo.ferreira"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }
    }
}
