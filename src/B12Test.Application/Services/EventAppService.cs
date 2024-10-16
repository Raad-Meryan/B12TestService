using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using B12Test.Authorization.Users;
using B12Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B12Test.Services.Dto;
using Microsoft.EntityFrameworkCore;
using UserDto = B12Test.Users.Dto.UserDto;

namespace B12Test.Services
{
    //[AllowAnonymous]
    public class EventAppService : ApplicationService, IEventAppService
    {
        private readonly EventManager _eventManager;
        private readonly IRepository<Event, Guid> _eventRepository; 
        private readonly IRepository<EventRegistration, Guid> _eventRegistrationRepository; 
        private readonly IRepository<User, long> _userRepository;

        public EventAppService(
            EventManager eventManager,
            IRepository<Event, Guid> eventRepository,
            IRepository<EventRegistration, Guid> eventRegistrationRepository,
            IRepository<User, long> userRepository
        )
        {
            _eventManager = eventManager;
            _eventRepository = eventRepository;
            _eventRegistrationRepository = eventRegistrationRepository;
            _userRepository = userRepository;
        }

        public async Task CreateEventAsync(string title, DateTime date, string description)
        {
            await _eventManager.CreateEventAsync(title, date, description);
        }

        public async Task RegisterUserAsync(Guid eventId, long userId)
        {
            await _eventManager.RegisterUserAsync(eventId, userId);
        }

        public async Task CancelEventAsync(Guid eventId)
        {
            await _eventManager.CancelEventAsync(eventId);
        }

        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllListAsync();
            return ObjectMapper.Map<List<EventDto>>(events);
        }

        public async Task<List<UserDto>> GetRegisteredUsersForEventAsync(Guid eventId)
        {
            var registrations = await _eventRegistrationRepository.GetAllListAsync(r => r.EventId == eventId);
            var userIds = registrations.Select(r => r.UserId).ToList();
            var users = await _userRepository.GetAllListAsync(u => userIds.Contains(u.Id));
            return ObjectMapper.Map<List<UserDto>>(users);
        }

        public async Task AddSpeakerToEventAsync(Guid eventId, Guid speakerId)
        {
            var @event = await _eventRepository.GetAllIncluding(e => e.EventSpeakers)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (@event == null)
            {
                throw new Exception("Event not found.");
            }

            var speakerExists = @event.EventSpeakers.Any(es => es.SpeakerId == speakerId);
            if (!speakerExists)
            {
                @event.EventSpeakers.Add(new EventSpeaker
                {
                    EventId = eventId,
                    SpeakerId = speakerId
                });

                await _eventRepository.UpdateAsync(@event);
            }
        }

        public async Task RemoveSpeakerFromEventAsync(Guid eventId, Guid speakerId)
        {
            var @event = await _eventRepository.GetAllIncluding(e => e.EventSpeakers)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (@event == null)
            {
                throw new Exception("Event not found.");
            }

            var eventSpeaker = @event.EventSpeakers.FirstOrDefault(es => es.SpeakerId == speakerId);
            if (eventSpeaker != null)
            {
                @event.EventSpeakers.Remove(eventSpeaker);
                await _eventRepository.UpdateAsync(@event);
            }
        }


    }

}
