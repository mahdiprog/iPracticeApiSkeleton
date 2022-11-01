using iPractice.Application.Dtos;
using iPractice.Domain.Models;
using iPractice.Domain.Repositories;

namespace iPractice.Application.Services
{
    public class PsychologistService : IPsychologistService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPsychologistRepository _psychologistRepository;

        public PsychologistService(IClientRepository clientRepository, IPsychologistRepository psychologistRepository)
        {
            _clientRepository = clientRepository;
            _psychologistRepository = psychologistRepository;
        }

        public Task CreateAvailability(AvailabilityDto availability)
        {
            return _psychologistRepository.CreateAvailability(availability.PsychologistId,
                  new Availability(availability.DayOfWeek, availability.FromTime, availability.ToTime));
        }
    }
}
