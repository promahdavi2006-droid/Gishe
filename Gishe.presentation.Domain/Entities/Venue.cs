namespace TicketBooking.Domain.Entities;

public class Venue
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Address { get; private set; } = string.Empty;

    public int Capacity { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime EndTime { get; private set; }

    public string Description { get; private set; } = string.Empty;

    private readonly List<Session> _sessions = new();

    public IReadOnlyCollection<Session> Sessions =>
        _sessions.AsReadOnly();

    public Venue(
        string name,
        string address,
        int capacity,
        DateTime startTime,
        DateTime endTime,
        string description)
    {
        Name = name;
        Address = address;
        Description = description;

        SetCapacity(capacity);

        StartTime = startTime;
        EndTime = endTime;
    }

    public void SetCapacity(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException(
                "Capacity must be greater than zero.");

        Capacity = capacity;
    }

    public void AddSession(Session session)
    {
        ArgumentNullException.ThrowIfNull(session);

        _sessions.Add(session);
    }

    public void RemoveSession(Session session)
    {
        ArgumentNullException.ThrowIfNull(session);

        _sessions.Remove(session);
    }

    public void Update(
        string name,
        string address,
        int capacity,
        DateTime startTime,
        DateTime endTime,
        string description)
    {
        Name = name;
        Address = address;
        Description = description;

        SetCapacity(capacity);

        StartTime = startTime;
        EndTime = endTime;
    }
}