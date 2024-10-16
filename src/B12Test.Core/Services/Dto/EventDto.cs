using System;
using System.Collections.Generic;

namespace B12Test.Services.Dto
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
        public List<SpeakerDto> Speakers { get; set; }
    }
}
