using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DbContext.ModelConfiguration
{
    public class ShowTypeConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder
                .Ignore(p => p.GenresCollection);
            
            builder.Property(p => p.StartDate)
                .HasColumnType("date");

            builder.Property(p => p.EndDate)
                .HasColumnType("date");

        }
    }
}
