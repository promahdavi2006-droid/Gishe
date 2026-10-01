using Gishe.Presentation.Application.DTOs;
using MediatR;

namespace Gishe.Presention.Application.Queries.Venues;

public class GetVenueByIdQuery : IRequest<VenueDto?>
{
    public int Id { get; set; }

    public GetVenueByIdQuery(int id)
    {
        Id = id;
    }
}