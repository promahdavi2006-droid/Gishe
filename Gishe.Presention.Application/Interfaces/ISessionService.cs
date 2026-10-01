using Gishe.Presentation.Application.DTOs;

namespace Gishe.Presentation.Application.Interfaces;

public interface ISessionService
{
    Task<SessionDto> CreateAsync(
        SessionDto sessionDto,
        CancellationToken cancellationToken = default);

    Task<SessionDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SessionDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        int id,
        SessionDto sessionDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}