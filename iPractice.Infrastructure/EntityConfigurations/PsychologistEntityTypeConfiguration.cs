using iPractice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPractice.Infrastructure.EntityConfigurations;

class PsychologistEntityTypeConfiguration
    : IEntityTypeConfiguration<Psychologist>
{
    public void Configure(EntityTypeBuilder<Psychologist> psychologistConfiguration)
    {
        psychologistConfiguration.HasKey(psychologist => psychologist.Id);

        var navigation = psychologistConfiguration.Metadata.FindNavigation(nameof(Psychologist.Clients));

        // DDD Patterns comment:
        //Set as field (New since EF 1.1) to access the Clients collection property through its field
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        psychologistConfiguration.HasMany(p => p.Clients).WithMany(b => b.Psychologists);

        psychologistConfiguration.Metadata.FindNavigation(nameof(Psychologist.Availabilities)).SetPropertyAccessMode(PropertyAccessMode.Field);
        psychologistConfiguration.HasMany<Availability>(p => p.Availabilities);
    }
}
