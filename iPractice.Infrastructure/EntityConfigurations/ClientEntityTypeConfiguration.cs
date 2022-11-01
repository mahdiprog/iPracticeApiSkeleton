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

        var navigation = clientConfiguration.Metadata.FindNavigation(nameof(Client.Psychologists));

        // DDD Patterns comment:
        //Set as field (New since EF 1.1) to access the Clients collection property through its field
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        clientConfiguration.HasMany(p => p.Psychologists).WithMany(b => b.Clients);

        clientConfiguration.Metadata.FindNavigation(nameof(Client.Appointments)).SetPropertyAccessMode(PropertyAccessMode.Field);
        clientConfiguration.HasMany<Appointment>(p => p.Appointments);
    }

}
