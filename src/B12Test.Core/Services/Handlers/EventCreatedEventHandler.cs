using Abp.Events.Bus.Handlers;
using B12Test.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;

namespace B12Test.Services.Handlers
{
    public class EventCreatedEventHandler : IEventHandler<EventCreatedEvent>, ITransientDependency
    {
        private readonly ILogger<EventCreatedEventHandler> _logger;
        private readonly IRepository<Event, Guid> _eventRepository;

        public EventCreatedEventHandler(
            ILogger<EventCreatedEventHandler> logger,
            IRepository<Event, Guid> eventRepository) // Inject repository here
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public void HandleEvent(EventCreatedEvent eventData)
        {
            _logger.LogInformation($"Event created: {eventData.Title}, {eventData.Date}, {eventData.Description}");

            var existingEvent = _eventRepository.FirstOrDefault(e => e.Id == eventData.Id);
            if (existingEvent == null)
            {
                // Create a new event if it doesn't exist
                var newEvent = new Event
                {
                    Id = eventData.Id,
                    Title = eventData.Title,
                    Date = eventData.Date,
                    Description = eventData.Description
                };

                _eventRepository.Insert(newEvent);
                _logger.LogInformation("New event inserted into the database.");
            }
            else
            {
                // Update existing event
                existingEvent.Title = eventData.Title;
                existingEvent.Date = eventData.Date;
                existingEvent.Description = eventData.Description;

                _eventRepository.Update(existingEvent);
                _logger.LogInformation("Existing event updated in the database.");
            }
        }

    }
}
