using MediatR;

namespace Gishe.Presentation.Application.Commands.Events;

public class CreateEventCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;

    public decimal PricePerUnit { get; set; }

    public string Description { get; set; } = string.Empty;
}