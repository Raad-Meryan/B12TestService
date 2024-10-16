using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12Test.Entities
{
    public class Event : FullAuditedEntity<Guid>
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual bool IsCancelled { get; protected set; }

        public Event()
        {
            EventSpeakers = new List<EventSpeaker>();
        }
        public virtual ICollection<EventSpeaker> EventSpeakers { get; set; }
        public static Event Create(string title, DateTime date, string description = null)
        {
            var @event = new Event
            {
                Id = Guid.NewGuid(),
                Title = title,
                Date = date,
                Description = description
            };

            @event.CheckIfInFuture();
            return @event;
        }

        public void Cancel()
        {
            if (IsInPast())
            {
                throw new Exception("Cannot cancel an event in the past.");
            }
            IsCancelled = true;
        }

        private void CheckIfInFuture()
        {
            if (Date < DateTime.Now)
            {
                throw new Exception("Event date must be in the future.");
            }
        }

        public bool IsInPast()
        {
            return Date < DateTime.Now;
        }
    }
}
