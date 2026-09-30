using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Queries.Events;

public class GetEventsQueryHandler
    : IRequestHandler<GetEventsQuery, IReadOnlyList<EventDto>>
{
    private readonly IEventService _eventService;

    public GetEventsQueryHandler(
        IEventService eventService)
    {
        _eventService = eventService;
    }

    public Task<IReadOnlyList<EventDto>> Handle(
        GetEventsQuery request,
        CancellationToken cancellationToken)
    {
        return _eventService.GetAllAsync(
            cancellationToken);
    }
}