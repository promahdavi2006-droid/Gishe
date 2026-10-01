using MediatR;

namespace Gishe.Presentation.Application.Commands.Sessions;

public class UpdateSessionCommand : IRequest
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int VenueId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int TotalCapacity { get; set; }

    public decimal Price { get; set; }

    public SessionStatus Status { get; set; }
}