using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Queries.Venues;

public class GetVenueByIdQueryHandler
    : IRequestHandler<GetVenueByIdQuery, VenueDto?>
{
    private readonly IVenueService _venueService;

    public GetVenueByIdQueryHandler(
        IVenueService venueService)
    {
        _venueService = venueService;
    }

    public Task<VenueDto?> Handle(
        GetVenueByIdQuery request,
        CancellationToken cancellationToken)
    {
        return _venueService.GetByIdAsync(
            request.Id,
            cancellationToken);
    }
}