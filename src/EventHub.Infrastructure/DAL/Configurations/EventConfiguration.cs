using EventHub.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Infrastructure.DAL.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events","Event");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Description);
        builder.Property(u => u.Title);
        builder.Property(u => u.EventDate);
        builder.Property(u => u.Location);
    }    
}