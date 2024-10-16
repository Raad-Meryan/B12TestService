using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace B12Test.Entities
{
    public class Speaker : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 64;
        public const int MaxBioLength = 2048;

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [StringLength(MaxBioLength)]
        public virtual string Bio { get; set; }

        public virtual ICollection<EventSpeaker> EventSpeakers { get; set; }

        // Constructor with no return type
        public Speaker()
        {
            EventSpeakers = new List<EventSpeaker>();
        }
    }

}
