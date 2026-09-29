namespace Gishe.presentation.Domain.Entities;

public class Session
{
    public int Id { get; private set; }

    public DateTime StartDateTime { get; private set; }

    public DateTime EndDateTime { get; private set; }

    public int TotalCapacity { get; private set; }

    public int AvailableCapacity { get; private set; }

    public decimal Price { get; private set; }

    public int SoldCount { get; private set; }

    public SessionStatus Status { get; private set; }

    public Session(
        DateTime startDateTime,
        DateTime endDateTime,
        int totalCapacity,
        decimal price)
    {
        SetTimeAndDate(startDateTime, endDateTime);

        if (totalCapacity <= 0)
            throw new ArgumentException(
                "Total capacity must be greater than zero.");

        if (price < 0)
            throw new ArgumentException(
                "Price cannot be negative.");

        TotalCapacity = totalCapacity;
        AvailableCapacity = totalCapacity;
        Price = price;
        SoldCount = 0;
        Status = SessionStatus.Available;
    }

    public void SetTimeAndDate(
        DateTime startDateTime,
        DateTime endDateTime)
    {
        if (endDateTime <= startDateTime)
            throw new ArgumentException(
                "End time must be after start time.");

        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }

    public void Update(
        DateTime startDateTime,
        DateTime endDateTime,
        int totalCapacity,
        decimal price,
        SessionStatus status)
    {
        SetTimeAndDate(startDateTime, endDateTime);

        if (totalCapacity <= 0)
            throw new ArgumentException(
                "Total capacity must be greater than zero.");

        if (price < 0)
            throw new ArgumentException(
                "Price cannot be negative.");

        TotalCapacity = totalCapacity;
        AvailableCapacity = totalCapacity - SoldCount;
        Price = price;
        Status = status;
    }
}