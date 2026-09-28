using System;
using System.Collections.Generic;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace test.Class
{
    internal class Venue
    {
        private readonly List<Session> _sessions = new();

        private Venue()
        {
        }


        public Venue(string name, string address, DateTime startTime, DateTime endTime,
                     string description, int capacity)
        {


            Name = name;
            Address = address;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
            SetCapacity(capacity);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Description { get; private set; }
        public int Capacity { get; private set; }

        public IReadOnlyCollection<Session> Sessions => _sessions;

        public void SetCapacity(int capacity)
        {

            Capacity = capacity;
        }

        public void AddSession(Session session)
        {
            ArgumentNullException.ThrowIfNull(session);



            var overlaps = _sessions.Any(s => s != session &&
                                              s.StartDateTime < session.EndDateTime &&
                                              session.StartDateTime < s.EndDateTime);


            _sessions.Add(session);
            session.AttachTo(this);
        }

        public void RemoveSession(Session session)
        {
            ArgumentNullException.ThrowIfNull(session);


        }
    }
}
