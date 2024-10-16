using System;

namespace B12Test.Entities
{
    internal class EventCancelledEvent
    {
        public Event Event { get; private set; }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
