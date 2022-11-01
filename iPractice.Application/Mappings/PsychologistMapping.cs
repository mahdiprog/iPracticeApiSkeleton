using iPractice.Application.Dtos;
using iPractice.Domain.Models;

namespace iPractice.Application.Mappings
{
    public static class PsychologistMapping
    {
        public static IEnumerable<AvailabilityDto> ToAvailabilityDto(this Psychologist psychologist)
        {
            return psychologist.Availabilities.Select(a =>
                new AvailabilityDto
                {
                    PsychologistId = psychologist.Id,
                    AvailabilityId = a.Id,
                    FromTime = a.FromTime,
                    ToTime = a.ToTime,
                    DayOfWeek = a.DayOfWeek
                });
        }
        public static IEnumerable<AvailabilityDto> ToAvailabilityDto(this IEnumerable<Psychologist> psychologists)
        {
            return psychologists.SelectMany(ToAvailabilityDto);
        }
    }
}
