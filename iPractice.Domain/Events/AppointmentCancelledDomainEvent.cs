using iPractice.Domain.Models;
using MediatR;

namespace iPractice.Domain.Events;

public class AppointmentCancelledDomainEvent : INotification
{
    public Appointment Appointment { get; }

    public AppointmentCancelledDomainEvent(Appointment appointment)
    {
        Appointment = appointment;
    }
}

