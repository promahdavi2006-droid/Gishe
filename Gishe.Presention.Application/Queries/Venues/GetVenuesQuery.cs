using Gishe.Presentation.Application.DTOs;
using MediatR;

namespace Gishe.Presention.Application.Queries.Venues;

public class GetVenuesQuery
    : IRequest<IReadOnlyList<VenueDto>>
{
}