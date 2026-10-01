using MediatR;

namespace Gishe.Presentation.Application.Commands.Events;

public class UpdateEventCommand : IRequest
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal PricePerUnit { get; set; }

    public string Description { get; set; } = string.Empty;
}