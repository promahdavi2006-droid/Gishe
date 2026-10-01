namespace Gishe.Presentation.Application.DTOs;

public class EventDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal PricePerUnit { get; set; }

    public string Description { get; set; } = string.Empty;
}