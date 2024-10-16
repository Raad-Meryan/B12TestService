using Abp.Application.Services.Dto;
using B12Test.Services.Dto;
using B12Test.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace B12Test.Web.Host.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly ISpeakerAppService _speakerAppService;

        public SpeakersController(ISpeakerAppService speakerAppService)
        {
            _speakerAppService = speakerAppService;
        }

        [HttpGet("{id}")]
        public async Task<SpeakerDto> Get(Guid id)
        {
            return await _speakerAppService.GetSpeakerAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<SpeakerDto>> GetAll([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _speakerAppService.GetAllSpeakersAsync(input);
        }

        [HttpPost]
        public async Task<SpeakerDto> Create([FromBody] CreateSpeakerInput input)
        {
            return await _speakerAppService.CreateSpeakerAsync(input);
        }

        [HttpPut("{id}")]
        public async Task Update(Guid id, [FromBody] UpdateSpeakerInput input)
        {
            input.Id = id;
            await _speakerAppService.UpdateSpeakerAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _speakerAppService.DeleteSpeakerAsync(id);
        }
    }
    */
}
