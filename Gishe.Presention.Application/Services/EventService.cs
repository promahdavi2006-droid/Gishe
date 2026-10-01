using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;

namespace Gishe.Presention.Application.Services;

public class EventService : IEventService
{
    private readonly IUnitOfWork _unitOfWork;

    public EventService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EventDto> CreateAsync(
        EventDto eventDto,
        CancellationToken cancellationToken = default)
    {
        var @event = new Event(
            eventDto.Name,
            eventDto.PricePerUnit,
            eventDto.Description);

        _unitOfWork.AddEvent(@event);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(@event);
    }

    public async Task<EventDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var @event = await _unitOfWork.GetEventByIdAsync(
            id,
            cancellationToken);

        return @event is null
            ? null
            : MapToDto(@event);
    }

    public async Task<IReadOnlyList<EventDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var events = await _unitOfWork.GetEventsAsync(
            cancellationToken);

        return events.Select(MapToDto).ToList();
    }

    public async Task UpdateAsync(
        int id,
        EventDto eventDto,
        CancellationToken cancellationToken = default)
    {
        var @event = await _unitOfWork.GetEventByIdAsync(
            id,
            cancellationToken);

        if (@event is null)
            throw new KeyNotFoundException(
                $"Event with id {id} was not found.");

        @event.Update(
            eventDto.Name,
            eventDto.PricePerUnit,
            eventDto.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var @event = await _unitOfWork.GetEventByIdAsync(
            id,
            cancellationToken);

        if (@event is null)
            throw new KeyNotFoundException(
                $"Event with id {id} was not found.");

        _unitOfWork.RemoveEvent(@event);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static EventDto MapToDto(Event @event)
    {
        return new EventDto
        {
            Id = @event.Id,
            Name = @event.Name,
            PricePerUnit = @event.PricePerUnit,
            Description = @event.Description
        };
    }
}