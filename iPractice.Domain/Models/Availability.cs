using iPractice.Domain.SeedWork;
using System;

namespace iPractice.Domain.Models
{
    public class Availability : Entity
    {
        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime FromTime { get; private set; }
        public DateTime ToTime { get; private set; }
        public long? ClientId { get; private set; }

        public void SetAppointment(long clientId)
        {
            ClientId = clientId;
        }
    }
}