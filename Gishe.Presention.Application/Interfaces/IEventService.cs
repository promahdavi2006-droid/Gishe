using Gishe.Presentation.Application.DTOs;

namespace Gishe.Presentation.Application.Interfaces;

public interface IEventService
{
    Task<EventDto> CreateAsync(
        EventDto eventDto,
        CancellationToken cancellationToken = default);

    Task<EventDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<EventDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        int id,
        EventDto eventDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}