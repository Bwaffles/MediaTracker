using System;

namespace Domain
{
    public class WatchHistory
    {
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public DateTime WatchDate { get; set; }
        public int WatchNumber { get; set; }
    }
}