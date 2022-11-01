using iPractice.Domain.SeedWork;
using System;

namespace iPractice.Domain.Models
{
    public class Appointment : Entity
    {
        public Appointment()
        {
        }
        public Appointment(Client client, Availability availability, DateTime date)
        {
            Client = client;
            Availability = availability;
            Date = date;
        }

        public Client Client { get; init; }

        public Availability Availability { get; init; }
        public DateTime Date { get; init; }
    }
}
