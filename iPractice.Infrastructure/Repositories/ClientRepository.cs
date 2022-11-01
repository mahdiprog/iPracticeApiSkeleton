using iPractice.Domain.Models;
using iPractice.Domain.Repositories;
using iPractice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Appointment> AddAppointment(long clientId, long psychologistId, long availabilityId)
    {
        var client = await _context.Clients.Include(c => c.Psychologists)
            .SingleAsync(c => c.Id == clientId).ConfigureAwait(false);

        var psychologist = await _context.Psychologists.Include(c => c.Availabilities)
            .SingleAsync(c => c.Id == psychologistId).ConfigureAwait(false);

        var appointment = new Appointment(client, psychologist.Availabilities.Single(a => a.Id == availabilityId));

        client.AddAppointment(appointment);

        await _context.SaveEntitiesAsync();
        return appointment;
    }

    public async Task<Client> GetById(long clientId)
    {
        return await _context.Clients.FindAsync(clientId).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Psychologist>> GetPsychologists(long clientId)
    {
        var client = await _context.Clients.Include(c => c.Psychologists)
            .SingleAsync(c => c.Id == clientId).ConfigureAwait(false);
        return client.Psychologists;
    }
}
