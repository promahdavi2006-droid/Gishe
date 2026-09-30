using Gishe.Presentation.Application.DTOs;
using MediatR;

namespace Gishe.Presention.Application.Queries.Sessions;

public class GetSessionByIdQuery : IRequest<SessionDto?>
{
    public int Id { get; set; }

    public GetSessionByIdQuery(int id)
    {
        Id = id;
    }
}