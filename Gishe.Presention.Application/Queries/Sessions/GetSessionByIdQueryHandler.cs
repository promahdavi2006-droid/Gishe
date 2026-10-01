using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Queries.Sessions;

public class GetSessionByIdQueryHandler
    : IRequestHandler<GetSessionByIdQuery, SessionDto?>
{
    private readonly ISessionService _sessionService;

    public GetSessionByIdQueryHandler(
        ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public Task<SessionDto?> Handle(
        GetSessionByIdQuery request,
        CancellationToken cancellationToken)
    {
        return _sessionService.GetByIdAsync(
            request.Id,
            cancellationToken);
    }
}