using System.Threading.Tasks;
using System;

namespace B12Test.Services
{
    public interface IEventAppService
    {
        Task CreateEventAsync(string title, DateTime date, string description);
        Task RegisterUserAsync(Guid eventId, long userId);
        Task CancelEventAsync(Guid eventId);
        Task AddSpeakerToEventAsync(Guid eventId, Guid speakerId);
        Task RemoveSpeakerFromEventAsync(Guid eventId, Guid speakerId);

    }

}