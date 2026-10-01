using MediatR;

namespace Gishe.Presentation.Application.Commands.Events;

public class DeleteEventCommand : IRequest
{
    public int Id { get; set; }
}