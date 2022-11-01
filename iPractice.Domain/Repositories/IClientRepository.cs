using iPractice.Domain.Models;
using iPractice.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPractice.Domain.Repositories;


public interface IClientRepository : IRepository<Client>
{
    Task<Appointment> AddAppointment(long clientI, long psychologistId, long availabilityId);
    Task<Client> GetById(long clientId);

    Task<IEnumerable<Psychologist>> GetPsychologists(long clientId);
}
