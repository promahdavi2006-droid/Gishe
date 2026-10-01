using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Queries.Venues;

public class GetVenuesQueryHandler
    : IRequestHandler<GetVenuesQuery, IReadOnlyList<VenueDto>>
{
    private readonly IVenueService _venueService;

    public GetVenuesQueryHandler(
        IVenueService venueService)
    {
        _venueService = venueService;
    }

    public Task<IReadOnlyList<VenueDto>> Handle(
        GetVenuesQuery request,
        CancellationToken cancellationToken)
    {
        return _venueService.GetAllAsync(
            cancellationToken);
    }
}