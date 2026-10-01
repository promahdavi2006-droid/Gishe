using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Queries.Sessions;

public class GetSessionsQueryHandler
    : IRequestHandler<GetSessionsQuery, IReadOnlyList<SessionDto>>
{
    private readonly ISessionService _sessionService;

    public GetSessionsQueryHandler(
        ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public Task<IReadOnlyList<SessionDto>> Handle(
        GetSessionsQuery request,
        CancellationToken cancellationToken)
    {
        return _sessionService.GetAllAsync(
            cancellationToken);
    }
}