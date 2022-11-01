using iPractice.Domain.Models;
using iPractice.Domain.Repositories;
using iPractice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace iPractice.Infrastructure.Repositories;

public class PsychologistRepository
    : IPsychologistRepository
{
    private readonly ApplicationDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public PsychologistRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task CreateAvailability(long psychologistId, Availability availability)
    {
        var psychologist = await GetById(psychologistId);
        psychologist.SetAvailability(availability);
        await _context.SaveEntitiesAsync();
    }

    public async Task<IEnumerable<Psychologist>> GetByIdsIncludeNotOccupiedAvailability(params long[] psychologistIds)
    {
        return await _context.Psychologists
            .Include(p => p.Availabilities.Where(a => a.Appointment != null))
            .Where(p => psychologistIds.Contains(p.Id))
            .ToListAsync().ConfigureAwait(false);
    }

    public async Task<Psychologist> GetById(long psychologistId)
    {
        return await _context.Psychologists.FindAsync(psychologistId).ConfigureAwait(false);
    }
}
