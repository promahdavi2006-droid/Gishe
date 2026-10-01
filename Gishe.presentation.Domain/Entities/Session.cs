using Gishe.presentation.Domain.Enums;

namespace Gishe.presentation.Domain.Entities;

public class Session
{
    public int Id { get; private set; }

    public int EventId { get; private set; }

    public int VenueId { get; private set; }

    public DateTime StartDateTime { get; private set; }

    public DateTime EndDateTime { get; private set; }

    public int TotalCapacity { get; private set; }

    public int AvailableCapacity { get; private set; }

    public decimal Price { get; private set; }

    public int SoldCount { get; private set; }

    public SessionStatus Status { get; private set; }

    public Session(
        int eventId,
        int venueId,
        DateTime startDateTime,
        DateTime endDateTime,
        int totalCapacity,
        decimal price)
    {
        if (eventId <= 0)
            throw new ArgumentException(
                "EventId must be greater than zero.");

        if (venueId <= 0)
            throw new ArgumentException(
                "VenueId must be greater than zero.");

        if (totalCapacity <= 0)
            throw new ArgumentException(
                "Total capacity must be greater than zero.");

        if (price < 0)
            throw new ArgumentException(
                "Price cannot be negative.");

        EventId = eventId;
        VenueId = venueId;

        SetTimeAndDate(
            startDateTime,
            endDateTime);

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
        int eventId,
        int venueId,
        DateTime startDateTime,
        DateTime endDateTime,
        int totalCapacity,
        decimal price,
        SessionStatus status)
    {
        if (eventId <= 0)
            throw new ArgumentException(
                "EventId must be greater than zero.");

        if (venueId <= 0)
            throw new ArgumentException(
                "VenueId must be greater than zero.");

        if (totalCapacity <= 0)
            throw new ArgumentException(
                "Total capacity must be greater than zero.");

        if (price < 0)
            throw new ArgumentException(
                "Price cannot be negative.");

        if (totalCapacity < SoldCount)
            throw new ArgumentException(
                "Total capacity cannot be less than sold count.");

        EventId = eventId;
        VenueId = venueId;

        SetTimeAndDate(
            startDateTime,
            endDateTime);

        TotalCapacity = totalCapacity;
        AvailableCapacity = totalCapacity - SoldCount;
        Price = price;
        Status = status;
    }
}