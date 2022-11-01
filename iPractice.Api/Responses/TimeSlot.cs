using System;

namespace iPractice.Api.Responses
{
    public record TimeSlot
    {
        public long AvailabilityId { get; init; }
        public long PsychologistId { get; init; }
        public DateTime FromTime { get; init; }
        public DateTime ToTime { get; init; }
        public DayOfWeek DayOfWeek { get; init; }
    }
}