using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Commands.Sessions;

public class UpdateSessionCommandHandler
    : IRequestHandler<UpdateSessionCommand>
{
    private readonly ISessionService _sessionService;

    public UpdateSessionCommandHandler(
        ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public async Task Handle(
        UpdateSessionCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new SessionDto
        {
            Id = request.Id,
            EventId = request.EventId,
            VenueId = request.VenueId,
            StartDateTime = request.StartDateTime,
            EndDateTime = request.EndDateTime,
            TotalCapacity = request.TotalCapacity,
            Price = request.Price,
            Status = request.Status
        };

        await _sessionService.UpdateAsync(
            request.Id,
            dto,
            cancellationToken);
    }
}