using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12Test.Entities
{
    public class EventSpeaker : Entity
    {
        public virtual Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual Guid SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }
    }
}
