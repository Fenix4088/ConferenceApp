using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Conferences.Api.Controllers;

[Authorize(Policy = Policy)]
internal class ConferenceController(IConferenceService conferenceService) : BaseController
{
    private const string Policy = "conferences";
    
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<ConferenceDetailsDto>> Get(Guid id)
    {
        return OkOrNotFound(await conferenceService.GetAsync(id));
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IReadOnlyList<ConferenceDto>>> GetAllAsync()
    {
        return Ok(await conferenceService.GetAllAsync());
    }
    
    [HttpPost]
    public async Task<ActionResult> AddAsync(ConferenceDetailsDto conferenceDetailsDto)
    {
        await conferenceService.AddAsync(conferenceDetailsDto);
        return CreatedAtAction(nameof(Get), new { id = conferenceDetailsDto.Id }, null);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAsync(Guid id, ConferenceDetailsDto conferenceDetailsDto)
    {
        conferenceDetailsDto.Id = id;
        await conferenceService.UpdateAsync(conferenceDetailsDto);
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await conferenceService.DeleteAsync(id);
        return NoContent();
    }
}