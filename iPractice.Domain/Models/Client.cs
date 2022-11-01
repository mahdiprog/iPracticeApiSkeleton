using iPractice.Domain.Events;
using iPractice.Domain.Exceptions;
using iPractice.Domain.SeedWork;
using System.Collections.Generic;

namespace iPractice.Domain.Models
{
    public class Client : Entity, IAggregateRoot
    {
        private readonly List<Psychologist> _psychologists = new();
        public IReadOnlyCollection<Psychologist> Psychologists => _psychologists;
        private readonly List<Appointment> _appointments = new();
        public IReadOnlyCollection<Appointment> Appointments => _appointments;
        public string Name { get; private set; }

        public Client(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddPsychologist(Psychologist psychologist)
        {
            if (_psychologists.Count >= 2)
                throw new PsychologistCountExceededDomainException();

            AddDomainEvent(new PsychologistSetForClientDomainEvent(psychologist, Id));
            _psychologists.Add(psychologist);
        }



        public void AddAppointment(Appointment appointment)
        {
            //todo: check if this appointment don't have conflict with others

            AddDomainEvent(new AppointmentCreatedDomainEvent(appointment, Id));
            _appointments.Add(appointment);
        }
    }
}