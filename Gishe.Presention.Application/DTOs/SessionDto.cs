namespace Gishe.Presentation.Application.DTOs;

public class SessionDto
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int VenueId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int TotalCapacity { get; set; }

    public int AvailableCapacity { get; set; }

    public decimal Price { get; set; }

    public int SoldCount { get; set; }

    public SessionStatus Status { get; set; }
}