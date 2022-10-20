using Microsoft.OpenApi.Models;
using System.ComponentModel;

namespace Api.Extensions.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JSON Web Token based security",
            };

            var securityReq = new OpenApiSecurityRequirement()
                {{
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } 
                    }, 
                    new string[] {}
                }};

            services.AddSwaggerGen(o =>
            {
                o.AddSecurityDefinition("Bearer", securityScheme);
                o.AddSecurityRequirement(securityReq);
            });
        }

        public static void UseSwaggerConfiguration(this WebApplication application)
        {
            // Configure the HTTP request pipeline.
            if (application.Environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI();
            }
        }
    }
}
