using System;

namespace Domain
{
    public class Watch
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public decimal Rating { get; set; }
        public int MovieId { get; set; }
    }
}