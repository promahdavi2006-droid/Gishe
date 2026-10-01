using MediatR;

namespace Gishe.Presention.Application.Commands.Sessions;

public class CreateSessionCommand : IRequest<int>
{
    public int EventId { get; set; }

    public int VenueId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int TotalCapacity { get; set; }

    public decimal Price { get; set; }

    public SessionStatus Status { get; set; }
}