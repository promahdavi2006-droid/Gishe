using Gishe.Presentation.Application.DTOs;
using MediatR;

namespace Gishe.Presention.Application.Queries.Events;

public class GetEventByIdQuery : IRequest<EventDto?>
{
    public int Id { get; set; }

    public GetEventByIdQuery(int id)
    {
        Id = id;
    }
}