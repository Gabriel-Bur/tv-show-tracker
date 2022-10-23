using Api.DbContext.ModelConfiguration;
using Api.Extensions;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Api.DbContext
{
    public class ApplicationDbContext :  IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShowTypeConfiguration());

            builder.Seed();

            base.OnModelCreating(builder);
        }


        public DbSet<Show> Shows { get; set; }
    }
}
