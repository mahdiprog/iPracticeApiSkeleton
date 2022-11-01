using iPractice.Domain.Events;
using iPractice.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;

namespace iPractice.Domain.Models
{
    public class Psychologist : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public IReadOnlyCollection<Client> Clients { get; private set; }

        private readonly List<Availability> _availabilities = new();
        public IReadOnlyCollection<Availability> Availabilities => _availabilities;
        public Psychologist(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetAvailability(Availability availability)
        {
            //todo: check if the availability has conflict with others

            if (availability.IsTransient())
            {
                _availabilities.Add(availability);
            }
            else
            {
                Availability currentAvailability = _availabilities.FirstOrDefault(a => a.Id == availability.Id);
                _availabilities.Remove(currentAvailability);
                _availabilities.Add(availability);
                AddDomainEvent(new AvailabilityUpdatedDomainEvent(availability, Id));
            }
        }
    }
}