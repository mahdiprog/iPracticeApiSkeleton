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

        psychologistConfiguration.HasMany(p => p.Clients).WithMany(b => b.Psychologists);

        psychologistConfiguration.Metadata.FindNavigation(nameof(Psychologist.Availabilities)).SetPropertyAccessMode(PropertyAccessMode.Field);
        psychologistConfiguration.HasMany<Availability>(p => p.Availabilities)
            .WithOne(a => a.Psychologist);
    }
}
