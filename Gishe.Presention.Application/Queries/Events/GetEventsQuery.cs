using Gishe.Presentation.Application.DTOs;
using MediatR;

namespace Gishe.Presention.Application.Queries.Events;

public class GetEventsQuery
    : IRequest<IReadOnlyList<EventDto>>
{
}