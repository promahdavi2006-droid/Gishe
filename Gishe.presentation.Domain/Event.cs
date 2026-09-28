using System;
using System.Collections.Generic;
using System.Text;

namespace test.Class
{
    public class Event
    {
        private readonly List<Session> _sessions = new();

        private Event() { }

        public Event(string name, decimal pricePerUnit, string description, ServicesCategory category)
        {


            Name = name;
            PricePerUnit = pricePerUnit;
            Description = description;
            Category = category;
            Status = ServicesStatus.Draft;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; private set; }
        public string Description { get; private set; }
        public ServicesCategory Category { get; private set; }
        public ServicesStatus Status { get; private set; }

        public IReadOnlyCollection<Session> Sessions => _sessions;


        public void SetCapacity(int capacity)
        {


            foreach (var session in _sessions)
                session.SetCapacity(capacity);
        }

        public void ChangeStatus(ServicesStatus status) => Status = status;

        public void AddSession(Session session)
        {
            ArgumentNullException.ThrowIfNull(session);


            _sessions.Add(session);
            session.AttachTo(this);
        }
    }
}
