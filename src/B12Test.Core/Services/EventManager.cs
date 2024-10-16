using Abp.Domain.Repositories;
using Abp.Events.Bus;
using B12Test.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace B12Test.Services
{
    public class EventManager
    {
        private readonly IRepository<Event, Guid> _eventRepository;
        private readonly IRepository<EventRegistration, Guid> _eventRegistrationRepository;
        private readonly IEventBus _eventBus;

        public EventManager(IRepository<Event, Guid> eventRepository, IRepository<EventRegistration, Guid> eventRegistrationRepository, IEventBus eventBus)
        {
            _eventRepository = eventRepository;
            _eventRegistrationRepository = eventRegistrationRepository;
            _eventBus = eventBus;
        }


        public async Task RegisterUserAsync(Guid eventId, long userId)
        {
            var @event = await _eventRepository.GetAsync(eventId);
            if (@event == null || @event.IsInPast())
            {
                throw new Exception("Cannot register for an event that is in the past.");
            }

            var registration = EventRegistration.Create(eventId, userId);
            await _eventRegistrationRepository.InsertAsync(registration);
        }
        [AllowAnonymous]
        public async Task<Event> CreateEventAsync(string title, DateTime date, string description = null)
        {
            var @event = Event.Create(title, date, description);
            await _eventRepository.InsertAsync(@event);

            return @event;
        }

        public async Task CancelEventAsync(Guid eventId)
        {
            var @event = await _eventRepository.GetAsync(eventId);
            if (@event == null)
            {
                throw new Exception("Event not found.");
            }

            @event.Cancel();
            await _eventRepository.UpdateAsync(@event);
            
        }
    }

}

