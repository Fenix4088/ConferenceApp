using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Speakers.Api.Controllers;

internal class SpeakersController(ISpeakersService speakersService) : BaseController
{
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SpeakerDto>> Get(Guid id)
    {
        return OkOrNotFound(await speakersService.GetAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<SpeakerDto>>> GetAll()
    {
        var speakers = await speakersService.GetAllAsync();
        return Ok(speakers);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SpeakerDto speakerDto)
    {
        await speakersService.AddAsync(speakerDto);
        return CreatedAtAction(nameof(Get), new { email = speakerDto.Email }, speakerDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, SpeakerDto speakerDto)
    {
        speakerDto.Id = id;
        await speakersService.UpdateAsync(speakerDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await speakersService.DeleteAsync(id);
        return NoContent();
    }
    
}