namespace Gishe.Presentation.Application.Interfaces;

public interface IUnitOfWork
{
    Task<Event?> GetEventByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Event>> GetEventsAsync(
        CancellationToken cancellationToken = default);

    void AddEvent(Event @event);

    void RemoveEvent(Event @event);


    Task<Session?> GetSessionByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Session>> GetSessionsAsync(
        CancellationToken cancellationToken = default);

    void AddSession(Session session);

    void RemoveSession(Session session);


    Task<Venue?> GetVenueByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Venue>> GetVenuesAsync(
        CancellationToken cancellationToken = default);

    void AddVenue(Venue venue);

    void RemoveVenue(Venue venue);


    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}