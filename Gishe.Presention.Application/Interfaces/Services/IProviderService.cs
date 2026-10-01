using Gishe.Presentation.Application.DTOs.Users;

namespace Gishe.Presentation.Application.Interfaces.Services;

public interface IProviderService
{
    Task<ProviderDto?> GetByIdAsync(Guid id);

    Task<List<ProviderDto>> GetAllAsync();

    Task<ProviderDto> CreateAsync(ProviderDto dto);

    Task<bool> UpdateAsync(Guid id, ProviderDto dto);

    Task<bool> DeleteAsync(Guid id);
}
