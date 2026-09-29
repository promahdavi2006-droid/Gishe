using Gishe.Presention.Application.DTOs.Users;

namespace Gishe.Presention.Application.Interfaces.Services;

public interface IConsumerService
{
    Task<ConsumerDto?> GetByIdAsync(Guid id);

    Task<List<ConsumerDto>> GetAllAsync();

    Task<ConsumerDto> CreateAsync(ConsumerDto dto);

    Task<bool> UpdateAsync(Guid id, ConsumerDto dto);

    Task<bool> DeleteAsync(Guid id);
}
