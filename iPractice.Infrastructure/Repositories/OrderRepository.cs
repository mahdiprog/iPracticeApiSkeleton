using iPractice.Domain.Models;
using iPractice.Domain.Repositories;
using iPractice.Domain.SeedWork;

namespace iPractice.Infrastructure.Repositories;

public class ClientRepository
    : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<Appointment> AddAppointment(long clientI, long psychologistId, long availabilityId)
    {
        throw new NotImplementedException();
    }

    public Task<Client> GetById(long clientId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Psychologist>> GetPsychologists(long clientId)
    {
        throw new NotImplementedException();
    }
}
