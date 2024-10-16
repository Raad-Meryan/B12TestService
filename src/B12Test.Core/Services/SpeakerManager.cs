using Abp.Domain.Repositories;
using B12Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12Test.Services
{
    public class SpeakerManager
    {
        private readonly IRepository<Speaker, Guid> _speakerRepository;

        public SpeakerManager(IRepository<Speaker, Guid> speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public async Task<Speaker> CreateSpeakerAsync(string name, string bio)
        {
            var speaker = new Speaker
            {
                Id = Guid.NewGuid(),
                Name = name,
                Bio = bio
            };
            await _speakerRepository.InsertAsync(speaker);
            return speaker;
        }

        public async Task<Speaker> GetSpeakerAsync(Guid id)
        {
            return await _speakerRepository.GetAsync(id);
        }
        
        public async Task<Speaker> DeleteSpeakerAsync (Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            await _speakerRepository.DeleteAsync(speaker);
            return speaker;
        }
    }
    
}
