using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using B12Test.Entities;
using B12Test.Services.Dto;

namespace B12Test.Services
{
    public class SpeakerAppService : AsyncCrudAppService<Speaker, SpeakerDto, Guid, PagedAndSortedResultRequestDto, CreateSpeakerInput, UpdateSpeakerInput>, ISpeakerAppService
    {
        public SpeakerAppService(IRepository<Speaker, Guid> repository) : base(repository)
        {
        }

        public async Task<SpeakerDto> CreateSpeakerAsync(CreateSpeakerInput input)
        {
            // Validate the input if necessary
            if (string.IsNullOrEmpty(input.Name))
            {
                throw new Exception("Name is required");
            }

            var speaker = new Speaker
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                Bio = input.Bio
            };

            // Make sure the repository is injected and used properly
            await Repository.InsertAsync(speaker);

            // Return the DTO
            return ObjectMapper.Map<SpeakerDto>(speaker);
        }

        public async Task<SpeakerDto> GetSpeakerAsync(Guid id)
        {
            var speaker = await Repository.GetAsync(id); // Use async version
            return ObjectMapper.Map<SpeakerDto>(speaker);
        }

        public async Task UpdateSpeakerAsync(UpdateSpeakerInput input)
        {
            var speaker = await Repository.GetAsync(input.Id);
            speaker.Name = input.Name;
            speaker.Bio = input.Bio;
            await Repository.UpdateAsync(speaker); // Use async version
        }

        public async Task DeleteSpeakerAsync(Guid id)
        {
            var speaker = await Repository.GetAsync(id);
            await Repository.DeleteAsync(speaker); // Use async version
        }

        public async Task<PagedResultDto<SpeakerDto>> GetAllSpeakersAsync(PagedAndSortedResultRequestDto input)
        {
            var speakers = await Repository.GetAllListAsync(); // Use async version
            return new PagedResultDto<SpeakerDto>
            {
                TotalCount = speakers.Count(),
                Items = ObjectMapper.Map<List<SpeakerDto>>(speakers)
            };
        }

    }
}
