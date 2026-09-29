namespace TicketBooking.Domain.Entities;

public class Event
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public decimal PricePerUnit { get; private set; }

    public string Description { get; private set; } = string.Empty;

    public Event(
        string name,
        decimal pricePerUnit,
        string description)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Description = description;
    }

    public void Update(
        string name,
        decimal pricePerUnit,
        string description)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Description = description;
    }
}