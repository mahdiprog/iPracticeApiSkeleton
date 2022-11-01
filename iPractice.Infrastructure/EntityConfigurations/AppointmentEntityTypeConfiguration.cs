using iPractice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPractice.Infrastructure.EntityConfigurations;

class AppointmentEntityTypeConfiguration
    : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> configuration)
    {
        configuration.HasKey(a => a.Id);
        configuration.Property(o => o.Id).ValueGeneratedOnAdd();

        configuration.HasOne(p => p.Availability)
            .WithOne(b => b.Appointment)
            .HasForeignKey<Availability>(a => a.Id);
    }

}
