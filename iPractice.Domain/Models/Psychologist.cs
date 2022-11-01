using iPractice.Domain.Events;
using iPractice.Domain.Exceptions;
using iPractice.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;

namespace iPractice.Domain.Models
{
    public class Psychologist : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        private readonly List<Client> _clients = new();
        public IReadOnlyCollection<Client> Clients => _clients;

        private readonly List<Availability> _availabilities = new();
        public IReadOnlyCollection<Availability> Availabilities => _availabilities;
        public Psychologist(long id, string name)
        {
            Id = id;
            Name = name;
        }

        internal void AddClient(Client client)
        {
            _clients.Add(client);
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

        public void SetAppointment(long clientId, long availabilityId)
        {
            Availability availability = _availabilities.FirstOrDefault(a => a.Id == availabilityId);
            if (availability == null)
                throw new AvailabilityNotFoundDomainException();

            if (availability.ClientId.HasValue)
                throw new AvailabilityOccupiedDomainException();

            availability.SetAppointment(clientId);
        }
    }
}