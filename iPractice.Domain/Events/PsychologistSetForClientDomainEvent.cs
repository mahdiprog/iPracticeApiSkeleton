using iPractice.Domain.Models;
using MediatR;

namespace iPractice.Domain.Events
{
    /// <summary>
    /// Event used when a psychologist has been assigned to a client
    /// </summary>
    public class PsychologistSetForClientDomainEvent : INotification
    {
        public long ClientId { get; }
        public Psychologist Psychologist { get; }

        public PsychologistSetForClientDomainEvent(Psychologist psychologist, long clientId)
        {
            Psychologist = psychologist;
            ClientId = clientId;
        }
    }
}
