using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Queries.Events;

public class GetEventByIdQueryHandler
    : IRequestHandler<GetEventByIdQuery, EventDto?>
{
    private readonly IEventService _eventService;

    public GetEventByIdQueryHandler(
        IEventService eventService)
    {
        _eventService = eventService;
    }

    public Task<EventDto?> Handle(
        GetEventByIdQuery request,
        CancellationToken cancellationToken)
    {
        return _eventService.GetByIdAsync(
            request.Id,
            cancellationToken);
    }
}