using iPractice.Api.Responses;
using iPractice.Application.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace iPractice.Api.Mappings
{
    public static class AvailabilityMapping
    {
        public static TimeSlot ToApiResponse(this AvailabilityDto availability)
        {
            return
                new TimeSlot()
                {
                    PsychologistId = availability.PsychologistId,
                    AvailabilityId = availability.AvailabilityId,
                    FromTime = availability.FromTime,
                    ToTime = availability.ToTime,
                    DayOfWeek = availability.DayOfWeek
                };
        }
        public static IEnumerable<TimeSlot> ToApiResponse(this IEnumerable<AvailabilityDto> availabilities)
        {
            return availabilities.Select(ToApiResponse);
        }
    }
}
