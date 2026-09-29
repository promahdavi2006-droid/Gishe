using Gishe.presentation.Domain.Entities.Users;
using Gishe.Presentation.Infrastructure.Persistence.Context;
using Gishe.Presention.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gishe.Presentation.Infrastructure.Repositories;

public class ConsumerRepository : IConsumerRepository
{
    private ApplicationDbContext _context;
    public ConsumerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Consumer?> GetByIdAsync(Guid id)
    {
        return await _context.Consumers
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<Consumer>> GetAllAsync()
    {
        return await _context.Consumers
            .ToListAsync();
    }
    public async Task AddAsync(Consumer consumer)
    {
        await _context.Consumers.AddAsync(consumer);
    }
    public void Update(Consumer consumer)
    {
        _context.Consumers.Update(consumer);
    }
    public void Delete(Consumer consumer)
    {
        _context.Consumers.Remove(consumer);
    }
}
