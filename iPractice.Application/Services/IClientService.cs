using iPractice.Application.Dtos;

namespace iPractice.Application.Services;

public interface IClientService
{
    Task<IEnumerable<AvailabilityDto>> GetAvailableTimeSlots(long clientId);
    Task CreateAppointment(long clientId, long psychologistId, long availabilityId, DateTime date);
}