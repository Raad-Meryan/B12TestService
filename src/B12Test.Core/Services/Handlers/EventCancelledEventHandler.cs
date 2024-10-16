using Abp.Events.Bus.Handlers;
using B12Test.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;

namespace B12Test.Services.Handlers
{
    internal class EventCancelledEventHandler : IEventHandler<EventCancelledEvent>, ITransientDependency
    {
        private readonly ILogger<EventCancelledEventHandler> _logger;
        private readonly IRepository<Event, Guid> _eventRepository;

        public EventCancelledEventHandler(
            ILogger<EventCancelledEventHandler> logger,
            IRepository<Event, Guid> eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public void HandleEvent(EventCancelledEvent eventData)
        {
            _logger.LogInformation($"Event Cancelled: {eventData.Event.Title}");
            // deleting the event from the database using the ID if the event is existing
            var existingEvent = _eventRepository.FirstOrDefault(e => e.Id == eventData.Event.Id);
            if (existingEvent != null)
            {
                _eventRepository.Delete(existingEvent);
            }
        }
    }
}
