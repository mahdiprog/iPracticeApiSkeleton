using iPractice.Domain.Events;
using iPractice.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace iPractice.Application.DomainEventHandlers;

public class AppointmentCreatedDomainEventHandler
                : INotificationHandler<AppointmentCreatedDomainEvent>
{
    private readonly IClientRepository _clientRepository;
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly ILoggerFactory _logger;

    public AppointmentCreatedDomainEventHandler(
        IClientRepository clientRepository,
        ILoggerFactory logger,
        IPsychologistRepository psychologistRepository)
    {
        _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _psychologistRepository = psychologistRepository ?? throw new ArgumentNullException(nameof(psychologistRepository));
    }

    public async Task Handle(AppointmentCreatedDomainEvent appointmentCreatedDomainEvent, CancellationToken cancellationToken)
    {
        _logger.CreateLogger<AppointmentCreatedDomainEvent>()
            .LogTrace("Appointment with Id: {Id} has been successfully created",
                appointmentCreatedDomainEvent.Appointment.Id);

        // todo: publish integration event
    }
}
