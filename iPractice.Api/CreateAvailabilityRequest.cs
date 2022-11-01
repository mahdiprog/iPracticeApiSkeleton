using System;

namespace iPractice.Api
{
    public record CreateAvailabilityRequest
    {
        public DateTime FromTime { get; init; }
        public DateTime ToTime { get; init; }
        public DayOfWeek DayOfWeek { get; init; }
    }
}
