namespace Gishe.Presentation.Application.DTOs;

public class VenueDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Description { get; set; } = string.Empty;

    public int Capacity { get; set; }
}