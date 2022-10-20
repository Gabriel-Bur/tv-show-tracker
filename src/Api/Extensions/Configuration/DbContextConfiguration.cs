using Api.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions.Configuration
{
    public static class DbContextConfiguration
    {
        public static void AddDbContextConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            string connection = builder.Configuration.GetConnectionString("SqlConnection");

            // For Entity Framework
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            // For Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void UseDbContextConfiguration(this WebApplication application)
        {
            using var scope = application.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.EnsureCreated();
        }
    }
}
