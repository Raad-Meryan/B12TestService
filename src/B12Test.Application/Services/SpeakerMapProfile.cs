using AutoMapper;
using B12Test.Entities;
using B12Test.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12Test.Services
{
    public class SpeakerMapProfile : Profile
    {
        public SpeakerMapProfile()
        {
            CreateMap<Speaker, SpeakerDto>();
            CreateMap<CreateSpeakerInput, Speaker>();
            CreateMap<UpdateSpeakerInput, Speaker>();
        }
    }
}
