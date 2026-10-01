using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;

namespace Gishe.Presention.Application.Services;

public class SessionService : ISessionService
{
    private readonly IUnitOfWork _unitOfWork;

    public SessionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<SessionDto> CreateAsync(
        SessionDto sessionDto,
        CancellationToken cancellationToken = default)
    {
        var session = new Session(
            sessionDto.EventId,
            sessionDto.VenueId,
            sessionDto.StartDateTime,
            sessionDto.EndDateTime,
            sessionDto.TotalCapacity,
            sessionDto.Price);

        _unitOfWork.AddSession(session);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(session);
    }

    public async Task<SessionDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var session = await _unitOfWork.GetSessionByIdAsync(
            id,
            cancellationToken);

        return session is null
            ? null
            : MapToDto(session);
    }

    public async Task<IReadOnlyList<SessionDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var sessions = await _unitOfWork.GetSessionsAsync(
            cancellationToken);

        return sessions.Select(MapToDto).ToList();
    }

    public async Task UpdateAsync(
        int id,
        SessionDto sessionDto,
        CancellationToken cancellationToken = default)
    {
        var session = await _unitOfWork.GetSessionByIdAsync(
            id,
            cancellationToken);

        if (session is null)
            throw new KeyNotFoundException(
                $"Session with id {id} was not found.");

        session.Update(
            sessionDto.EventId,
            sessionDto.VenueId,
            sessionDto.StartDateTime,
            sessionDto.EndDateTime,
            sessionDto.TotalCapacity,
            sessionDto.Price,
            sessionDto.Status);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var session = await _unitOfWork.GetSessionByIdAsync(
            id,
            cancellationToken);

        if (session is null)
            throw new KeyNotFoundException(
                $"Session with id {id} was not found.");

        _unitOfWork.RemoveSession(session);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static SessionDto MapToDto(Session session)
    {
        return new SessionDto
        {
            Id = session.Id,
            EventId = session.EventId,
            VenueId = session.VenueId,
            StartDateTime = session.StartDateTime,
            EndDateTime = session.EndDateTime,
            TotalCapacity = session.TotalCapacity,
            AvailableCapacity = session.AvailableCapacity,
            Price = session.Price,
            SoldCount = session.SoldCount,
            Status = session.Status
        };
    }
}