using Gishe.Presentation.Application.DTOs;

namespace Gishe.Presentation.Application.Interfaces;

public interface IVenueService
{
    Task<VenueDto> CreateAsync(
        VenueDto venueDto,
        CancellationToken cancellationToken = default);

    Task<VenueDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<VenueDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        int id,
        VenueDto venueDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task AddSessionAsync(
        int venueId,
        int sessionId,
        CancellationToken cancellationToken = default);

    Task RemoveSessionAsync(
        int venueId,
        int sessionId,
        CancellationToken cancellationToken = default);
}