using System;
using System.Collections.Generic;

namespace BestTimeEvent
{
    public class BestTimeEventCalculator
    {
        private List<Events> _events;
        private List<KeyValuePair<string, Locations>> _locations;

        public BestTimeEventCalculator(List<Events> events,
            List<KeyValuePair<string, Locations>> locations)
        {
            _events = events;
            _locations = locations;
        }

        public BestTimeEventResult GetBestTimeEvents(DateTime currentStartTime, DateTime currentEndTime)
        {
            List<Events> bestEvents = new List<Events>();
            List<int> bestEventIDs = new List<int>();
            int totalPriority = 0;

            DateTime currentTime = currentStartTime;
            string from = null;

            while (currentTime < currentEndTime)
            {
                Events bestEvent = null;
                int bestPriority = 0;

                foreach (var evnt in _events)
                {
                    if (evnt.Start_Time >= currentTime && evnt.End_Time <= currentEndTime)
                    {
                        int travelTime = from != null ? 
                            _locations.Find(k => k.Key == from).Value
                            .GetTravelTime(evnt.Location) : 0;

                        DateTime arrivalTime = currentTime.AddMinutes(travelTime);

                        if (arrivalTime <= evnt.Start_Time && evnt.Priority > bestPriority)
                        {
                            bestEvent = evnt;
                            bestPriority = evnt.Priority;
                        }
                    }
                }

                if (bestEvent == null) break;

                bestEvents.Add(bestEvent);
                bestEventIDs.Add(bestEvent.Id);
                totalPriority += bestEvent.Priority;

                currentTime = bestEvent.End_Time;
                from = bestEvent.Location;

                _events.Remove(bestEvent);
            }

            int eventCount = bestEvents.Count;
            return new BestTimeEventResult (bestEventIDs, totalPriority, eventCount);
        }

    }
}
