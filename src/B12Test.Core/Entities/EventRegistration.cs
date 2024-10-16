using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12Test.Entities
{
    public class EventRegistration : CreationAuditedEntity<Guid>
    {
        public virtual Guid EventId { get; protected set; }
        public virtual long UserId { get; protected set; }

        protected EventRegistration()
        {
            // Protected constructor for Entity Framework
        }

        public static EventRegistration Create(Guid eventId, long userId)
        {
            return new EventRegistration
            {
                EventId = eventId,
                UserId = userId
            };
        }
    }
}
