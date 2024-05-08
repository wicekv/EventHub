using EventHub.Core.Entities;
using EventHub.Core.ValueObjects.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Infrastructure.DAL.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events","Event");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new EventId(e));

        builder.Property(u => u.Description)
            .HasConversion(u => u.Value, e => new Description(e));
        
        builder.Property(e => e.Title)
            .HasConversion(e => e.Value, e => new Title(e));

        builder.Property(e => e.EventDate);
        
        builder.Property(e => e.Location)
            .HasConversion(e => e.Value, e => new Location(e));
    }    
}