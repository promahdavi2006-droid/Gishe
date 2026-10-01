using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;

namespace Gishe.Presention.Application.Services;

public class VenueService : IVenueService
{
    private readonly IUnitOfWork _unitOfWork;

    public VenueService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<VenueDto> CreateAsync(
        VenueDto venueDto,
        CancellationToken cancellationToken = default)
    {
        var venue = new Venue(
            venueDto.Name,
            venueDto.Address,
            venueDto.Capacity,
            venueDto.StartTime,
            venueDto.EndTime,
            venueDto.Description);

        _unitOfWork.AddVenue(venue);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(venue);
    }

    public async Task<VenueDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var venue = await _unitOfWork.GetVenueByIdAsync(
            id,
            cancellationToken);

        return venue is null
            ? null
            : MapToDto(venue);
    }

    public async Task<IReadOnlyList<VenueDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var venues = await _unitOfWork.GetVenuesAsync(
            cancellationToken);

        return venues.Select(MapToDto).ToList();
    }

    public async Task UpdateAsync(
        int id,
        VenueDto venueDto,
        CancellationToken cancellationToken = default)
    {
        var venue = await _unitOfWork.GetVenueByIdAsync(
            id,
            cancellationToken);

        if (venue is null)
            throw new KeyNotFoundException(
                $"Venue with id {id} was not found.");

        venue.Update(
            venueDto.Name,
            venueDto.Address,
            venueDto.Capacity,
            venueDto.StartTime,
            venueDto.EndTime,
            venueDto.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var venue = await _unitOfWork.GetVenueByIdAsync(
            id,
            cancellationToken);

        if (venue is null)
            throw new KeyNotFoundException(
                $"Venue with id {id} was not found.");

        _unitOfWork.RemoveVenue(venue);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task AddSessionAsync(
        int venueId,
        int sessionId,
        CancellationToken cancellationToken = default)
    {
        var venue = await _unitOfWork.GetVenueByIdAsync(
            venueId,
            cancellationToken);

        if (venue is null)
            throw new KeyNotFoundException(
                $"Venue with id {venueId} was not found.");

        var session = await _unitOfWork.GetSessionByIdAsync(
            sessionId,
            cancellationToken);

        if (session is null)
            throw new KeyNotFoundException(
                $"Session with id {sessionId} was not found.");

        venue.AddSession(session);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveSessionAsync(
        int venueId,
        int sessionId,
        CancellationToken cancellationToken = default)
    {
        var venue = await _unitOfWork.GetVenueByIdAsync(
            venueId,
            cancellationToken);

        if (venue is null)
            throw new KeyNotFoundException(
                $"Venue with id {venueId} was not found.");

        var session = await _unitOfWork.GetSessionByIdAsync(
            sessionId,
            cancellationToken);

        if (session is null)
            throw new KeyNotFoundException(
                $"Session with id {sessionId} was not found.");

        venue.RemoveSession(session);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static VenueDto MapToDto(Venue venue)
    {
        return new VenueDto
        {
            Id = venue.Id,
            Name = venue.Name,
            Address = venue.Address,
            StartTime = venue.StartTime,
            EndTime = venue.EndTime,
            Description = venue.Description,
            Capacity = venue.Capacity
        };
    }
}