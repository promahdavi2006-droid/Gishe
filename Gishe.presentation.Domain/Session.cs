using System;
using System.Collections.Generic;
using System.Text;

namespace test.Class
{
    public class Session
    {
        public Session(int id,
            DateTime startDateTime,
            DateTime endDateTime,
            int totalCapacity,
            decimal price,
            ; int soldCount)
        {
            this.id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            TotalCapacity = totalCapacity;
            Price = price;
            SoldCount = soldCount;
        }

        public int id { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public int TotalCapacity { get; private set; }
        public decimal Price { get; private set; }
        public int SoldCount { get; private set; }
        public Event Event { get; set; }
        public Venue Venue { get; set; }

        public void SetTimeAndDate()
        {
            throw new NotImplementedException();
        }
    }
}
