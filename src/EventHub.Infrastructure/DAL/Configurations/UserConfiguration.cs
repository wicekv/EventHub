using EventHub.Core.Entities;
using EventHub.Core.Exceptions.Users;
using EventHub.Core.ValueObjects.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users","User");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasConversion(u => u.Value, u => new UserId(u));

        builder.Property(u => u.Email)
            .HasConversion(u => u.Value, u => new Email(u))
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(u => u.Password)
            .HasConversion(u => u.Value, u => new Password(u))
            .IsRequired();
        
        builder.HasMany(u => u.HostedEvents)
            .WithOne(e => e.Host)
            .HasForeignKey(e => e.HostId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.Registrations)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}