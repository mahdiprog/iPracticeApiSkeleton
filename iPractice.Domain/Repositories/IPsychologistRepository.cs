using iPractice.Domain.Models;
using iPractice.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPractice.Domain.Repositories;

public interface IPsychologistRepository : IRepository<Psychologist>
{
    Task CreateAvailability(long psychologistId, Availability availability);

    Task<IEnumerable<Psychologist>> GetByIdsIncludeNotOccupiedAvailability(params long[] psychologistIds);
    Task<Psychologist> GetById(long psychologistId);
}
