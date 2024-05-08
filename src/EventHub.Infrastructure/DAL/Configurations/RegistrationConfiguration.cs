using EventHub.Core.Entities;
using EventHub.Core.ValueObjects.Events;
using EventHub.Core.ValueObjects.Registrations;
using EventHub.Core.ValueObjects.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Infrastructure.DAL.Configurations;

internal sealed class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable("Registrations","Event");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasConversion(r => r.Value, r => new RegistrationId(r));
        
        builder
            .HasOne(r => r.User)
            .WithMany(u => u.Registrations)
            .HasForeignKey(r => r.UserId);

        builder
            .HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .HasForeignKey(r => r.EventId);
        
        builder.Property(r => r.EventId)
            .HasConversion(r => r.Value, r => new EventId(r));

        builder.Property(r => r.UserId)
            .HasConversion(r => r.Value, r => new UserId(r));

    }
}