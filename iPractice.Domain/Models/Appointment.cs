using iPractice.Domain.SeedWork;

namespace iPractice.Domain.Models
{
    public class Appointment : Entity
    {
        public Appointment()
        {
        }
        public Appointment(Client client, Availability availability)
        {
            Client = client;
            Availability = availability;
        }

        public Client Client { get; init; }

        public Availability Availability { get; init; }

    }
}
