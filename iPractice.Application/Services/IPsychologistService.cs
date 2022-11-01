using iPractice.Application.Dtos;

namespace iPractice.Application.Services;

public interface IPsychologistService
{
    Task CreateAvailability(AvailabilityDto availability);
}