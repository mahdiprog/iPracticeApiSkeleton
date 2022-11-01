using iPractice.Domain.Models;
using MediatR;

namespace iPractice.Domain.Events;

public class AvailabilityUpdatedDomainEvent
    : INotification
{
    public Availability Availability { get; private set; }
    public long PsychologistId { get; private set; }

    public AvailabilityUpdatedDomainEvent(Availability availability, long psychologistId)
    {
        Availability = availability;
        PsychologistId = psychologistId;
    }
}
