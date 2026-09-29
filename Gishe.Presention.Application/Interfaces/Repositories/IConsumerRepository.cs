using Gishe.presentation.Domain.Entities.Users;


namespace Gishe.Presention.Application.Interfaces.Repositories;

public interface IConsumerRepository
{
    Task<Consumer?> GetByIdAsync(Guid id);

    Task<List<Consumer>> GetAllAsync();

    Task AddAsync(Consumer consumer);

    void Update(Consumer consumer);

    void Delete(Consumer consumer);
}
