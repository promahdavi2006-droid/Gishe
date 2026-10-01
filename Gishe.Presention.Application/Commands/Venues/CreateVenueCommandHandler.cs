using Gishe.Presentation.Application.DTOs;
using Gishe.Presentation.Application.Interfaces;
using MediatR;

namespace Gishe.Presention.Application.Commands.Venues;

public class CreateVenueCommandHandler
    : IRequestHandler<CreateVenueCommand, int>
{
    private readonly IVenueService _venueService;

    public CreateVenueCommandHandler(
        IVenueService venueService)
    {
        _venueService = venueService;
    }

    public async Task<int> Handle(
        CreateVenueCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new VenueDto
        {
            Name = request.Name,
            Address = request.Address,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Description = request.Description,
            Capacity = request.Capacity
        };

        var result = await _venueService.CreateAsync(
            dto,
            cancellationToken);

        return result.Id;
    }
}