using iPractice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPractice.Infrastructure.EntityConfigurations;

class AvailabilityEntityTypeConfiguration
    : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> configuration)
    {
        configuration.HasKey(a => a.Id);
        configuration.Property(o => o.Id).ValueGeneratedOnAdd();

        configuration.HasOne(p => p.Psychologist).WithMany(b => b.Availabilities);
        configuration.HasOne(p => p.Appointment)
            .WithOne(b => b.Availability)
            .HasForeignKey<Appointment>(a => a.Id);
    }

}
