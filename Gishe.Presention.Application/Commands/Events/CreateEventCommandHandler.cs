using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Commands.Events;

public class CreateEventCommandHandler
    : IRequestHandler<CreateEventCommand, int>
{
    private readonly IEventService _eventService;

    public CreateEventCommandHandler(
        IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<int> Handle(
        CreateEventCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new EventDto
        {
            Name = request.Name,
            PricePerUnit = request.PricePerUnit,
            Description = request.Description
        };

        var result = await _eventService.CreateAsync(
            dto,
            cancellationToken);

        return result.Id;
    }
}