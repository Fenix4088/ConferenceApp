using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Conferences.Api.Controllers;

internal class HostController(IHostService hostService) : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<HostDetailsDto>> GetAsync(Guid id)
    {
        return OkOrNotFound(await hostService.GetAsync(id));
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<HostDto>>> GetAllAsync()
    {
        return Ok(await hostService.GetAllAsync());
    }
    
    [HttpPost]
    public async Task<ActionResult> AddAsync(HostDto hostDto)
    {
        await hostService.AddAsync(hostDto);
        return Ok();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAsync(Guid id, HostDetailsDto hostDetailsDto)
    {
        hostDetailsDto.Id = id;
        await hostService.UpdateAsync(hostDetailsDto);
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await hostService.DeleteAsync(id);
        return NoContent();
    }
}