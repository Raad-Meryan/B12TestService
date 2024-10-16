using System;
using Abp.Events.Bus;

namespace B12Test.Entities
{
    public class EventCreatedEvent 
    {
        public Event Event { get; private set; }

        // Required by IEventData}
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
