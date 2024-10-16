using Abp.Application.Services.Dto;
using System;

namespace B12Test.Services.Dto
{
    public class SpeakerDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
