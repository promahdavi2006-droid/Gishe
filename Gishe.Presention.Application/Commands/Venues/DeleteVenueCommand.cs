using MediatR;

namespace Gishe.Presentation.Application.Commands.Venues;

public class DeleteVenueCommand : IRequest
{
    public int Id { get; set; }
}