using Abp.Application.Services.Dto;
using B12Test.Entities;
using B12Test.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12Test.Services
{
    public interface ISpeakerAppService
    {
        Task<SpeakerDto> CreateSpeakerAsync(CreateSpeakerInput input);
        Task<SpeakerDto> GetSpeakerAsync(Guid id);
        Task UpdateSpeakerAsync(UpdateSpeakerInput input);
        Task DeleteSpeakerAsync(Guid id);
        Task<PagedResultDto<SpeakerDto>> GetAllSpeakersAsync(PagedAndSortedResultRequestDto input);

    }

    public class UpdateSpeakerInput : EntityDto<Guid>
    {
        [Required]
        [StringLength(Speaker.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(Speaker.MaxBioLength)]
        public string Bio { get; set; }
    }

    public class CreateSpeakerInput
    {
        [Required]
        [StringLength(Speaker.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(Speaker.MaxBioLength)]
        public string Bio { get; set; }
    }
}
