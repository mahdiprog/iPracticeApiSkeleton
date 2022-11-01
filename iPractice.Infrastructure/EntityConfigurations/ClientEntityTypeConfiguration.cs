using iPractice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPractice.Infrastructure.EntityConfigurations;

class ClientEntityTypeConfiguration
    : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> clientConfiguration)
    {
        clientConfiguration.HasKey(psychologist => psychologist.Id);

        clientConfiguration.Metadata.FindNavigation(nameof(Client.Appointments)).SetPropertyAccessMode(PropertyAccessMode.Field);
        clientConfiguration.HasMany<Appointment>(p => p.Appointments)
            .WithOne(a => a.Client);
    }

}
