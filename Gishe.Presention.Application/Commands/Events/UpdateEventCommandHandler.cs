using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Commands.Events;

public class UpdateEventCommandHandler
    : IRequestHandler<UpdateEventCommand>
{
    private readonly IEventService _eventService;

    public UpdateEventCommandHandler(
        IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task Handle(
        UpdateEventCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new EventDto
        {
            Id = request.Id,
            Name = request.Name,
            PricePerUnit = request.PricePerUnit,
            Description = request.Description
        };

        await _eventService.UpdateAsync(
            request.Id,
            dto,
            cancellationToken);
    }
}