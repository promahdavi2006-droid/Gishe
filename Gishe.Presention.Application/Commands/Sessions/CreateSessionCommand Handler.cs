using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Commands.Sessions;

public class CreateSessionCommandHandler
    : IRequestHandler<CreateSessionCommand, int>
{
    private readonly ISessionService _sessionService;

    public CreateSessionCommandHandler(
        ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public async Task<int> Handle(
        CreateSessionCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new SessionDto
        {
            EventId = request.EventId,
            VenueId = request.VenueId,
            StartDateTime = request.StartDateTime,
            EndDateTime = request.EndDateTime,
            TotalCapacity = request.TotalCapacity,
            Price = request.Price,
            Status = request.Status
        };

        var result = await _sessionService.CreateAsync(
            dto,
            cancellationToken);

        return result.Id;
    }
}