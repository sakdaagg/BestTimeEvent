using System.Collections.Generic;

namespace BestTimeEvent
{
    public class Locations
    {
        public Locations(string from)
        {
            From = from;
            Station_Minutes = new List<KeyValuePair<string, int>>();
        }
        public void AddTravelTime(string to, int time)
        {
            Station_Minutes.Add(new KeyValuePair<string, int>(to, time));
        }

        public int GetTravelTime(string to)
        {
            return Station_Minutes.Find(k => k.Key == to).Value;
        }

        public string From { get; set; }
        public List<KeyValuePair<string,int>> Station_Minutes { get; set; }
        
    }
}
