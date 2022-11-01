using iPractice.Domain.SeedWork;

namespace iPractice.Domain.Models
{
    public class Appointment : Entity
    {
        public Client Client { get; private set; }
        public Psychologist Psychologist { get; private set; }
        public Availability Availability { get; private set; }

    }
}
