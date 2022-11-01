using iPractice.Domain.Models;
using iPractice.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPractice.Domain.Repositories;

public interface IPsychologistRepository : IRepository<Psychologist>
{
    Task SetAppointment(long psychologistId, long clientId);

    Task<IEnumerable<Psychologist>> GetByIds(params long[] psychologistIds);
}
