using MediatR;

namespace Gishe.Presentation.Application.Commands.Sessions;

public class DeleteSessionCommand : IRequest
{
    public int Id { get; set; }
}