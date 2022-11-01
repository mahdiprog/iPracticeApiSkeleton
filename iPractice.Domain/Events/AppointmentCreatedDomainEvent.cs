using iPractice.Domain.Models;
using MediatR;

namespace iPractice.Domain.Events
{
    /// <summary>
    /// Event used when an order is created
    /// </summary>
    public class AppointmentCreatedDomainEvent : INotification
    {
        public long ClientId { get; }
        public Appointment Appointment { get; }

        public AppointmentCreatedDomainEvent(Appointment appointment, long clientId)
        {
            Appointment = appointment;
            ClientId = clientId;
        }
    }
}
