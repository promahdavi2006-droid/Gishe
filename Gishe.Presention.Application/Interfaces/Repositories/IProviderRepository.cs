using Gishe.presentation.Domain.Entities.Users;

namespace Gishe.Presentation.Application.Interfaces.Repositories;

public interface IProviderRepository
{
    Task<Provider?> GetByIdAsync(Guid id);

    Task<List<Provider>> GetAllAsync();

    Task AddAsync(Provider provider);

    Task UpdateAsync(Provider provider);

    Task DeleteAsync(Provider provider);

}
