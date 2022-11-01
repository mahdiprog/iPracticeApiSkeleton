using iPractice.Domain.SeedWork;
using System;

namespace iPractice.Domain.Models
{
    public class Availability : Entity
    {
        public Availability(DayOfWeek dayOfWeek, DateTime fromTime, DateTime toTime)
        {
            DayOfWeek = dayOfWeek;
            FromTime = fromTime;
            ToTime = toTime;
        }

        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime FromTime { get; private set; }
        public DateTime ToTime { get; private set; }
        public Psychologist Psychologist { get; private set; }
        public Appointment? Appointment { get; private set; }
    }
}