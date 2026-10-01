using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Commands.Events;

public class DeleteEventCommandHandler
    : IRequestHandler<DeleteEventCommand>
{
    private readonly IEventService _eventService;

    public DeleteEventCommandHandler(
        IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task Handle(
        DeleteEventCommand request,
        CancellationToken cancellationToken)
    {
        await _eventService.DeleteAsync(
            request.Id,
            cancellationToken);
    }
}