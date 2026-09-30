using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Commands.Venues;

public class UpdateVenueCommandHandler
    : IRequestHandler<UpdateVenueCommand>
{
    private readonly IVenueService _venueService;

    public UpdateVenueCommandHandler(
        IVenueService venueService)
    {
        _venueService = venueService;
    }

    public async Task Handle(
        UpdateVenueCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new VenueDto
        {
            Id = request.Id,
            Name = request.Name,
            Address = request.Address,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Description = request.Description,
            Capacity = request.Capacity
        };

        await _venueService.UpdateAsync(
            request.Id,
            dto,
            cancellationToken);
    }
}