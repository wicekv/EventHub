using EventHub.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users","User");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(u => u.Password)
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