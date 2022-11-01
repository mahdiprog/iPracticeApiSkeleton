using iPractice.Application.Dtos;
using iPractice.Application.Exceptions;
using iPractice.Application.Mappings;
using iPractice.Domain.Repositories;

namespace iPractice.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPsychologistRepository _psychologistRepository;

        public ClientService(IClientRepository clientRepository, IPsychologistRepository psychologistRepository)
        {
            _clientRepository = clientRepository;
            _psychologistRepository = psychologistRepository;
        }

        public async Task<IEnumerable<AvailabilityDto>> GetAvailableTimeSlots(long clientId)
        {
            Domain.Models.Client client = await _clientRepository.GetById(clientId);
            if (client == null)
            {
                throw new NotFoundException(nameof(client), clientId);
            }

            var psychologists =
                await _psychologistRepository.GetByIds(client.Psychologists.Select(p => p.Id)
                    .ToArray());
            return psychologists.ToAvailabilityDto();
        }

        public async Task CreateAppointment(long clientId, long psychologistId, long availabilityId)
        {
            await _clientRepository.AddAppointment(clientId,
                psychologistId, availabilityId);
        }
    }
}
