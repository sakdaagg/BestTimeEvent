using System.Collections.Generic;

namespace BestTimeEvent
{
    public class BestTimeEventResult
    {
        public BestTimeEventResult(List<int> bestEventIds, int total, int bestEventCount)
        {
            BestEventIds = bestEventIds;
            Total = total;
            BestEventCount = bestEventCount;
        }

        public List<int> BestEventIds { get; set; }
        public int Total { get; set; }
        public int BestEventCount { get; set; }
    }
}
