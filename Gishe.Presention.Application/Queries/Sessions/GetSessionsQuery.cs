using MediatR;

namespace Gishe.Presention.Application.Queries.Sessions;

public class GetSessionsQuery
    : IRequest<IReadOnlyList<SessionDto>>
{
}