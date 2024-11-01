using System;

namespace BestTimeEvent
{
    public class Events
    {
        public Events(int id, DateTime start_Time, DateTime end_Time, string location, int priority)
        {
            Id = id;
            Start_Time = start_Time;
            End_Time = end_Time;
            Location = location;
            Priority = priority;
        }

        public int Id { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public string Location { get; set; }
        public int Priority { get; set; }
    }
}


