using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Extensions.Configuration
{
    public static class AuthorizationConfiguration
    {
        public static void AddAuthorizationConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            // Adding Authentication
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
        }
    }
}
