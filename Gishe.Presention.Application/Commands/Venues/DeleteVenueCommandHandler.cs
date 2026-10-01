using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presentation.Application.Commands.Venues;

public class DeleteVenueCommandHandler
    : IRequestHandler<DeleteVenueCommand>
{
    private readonly IVenueService _venueService;

    public DeleteVenueCommandHandler(
        IVenueService venueService)
    {
        _venueService = venueService;
    }

    public async Task Handle(
        DeleteVenueCommand request,
        CancellationToken cancellationToken)
    {
        await _venueService.DeleteAsync(
            request.Id,
            cancellationToken);
    }
}