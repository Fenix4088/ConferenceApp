using Confab.Modules.Conferences.Core.DTO;

namespace Confab.Modules.Conferences.Core.Services;

internal interface IHostService
{
    Task AddAsync(HostDto hostDto);
    Task<HostDetailsDto> GetAsync(Guid id);
    Task<IReadOnlyList<HostDto>> GetAllAsync();
    Task UpdateAsync(HostDetailsDto hostDetailsDto);
    Task DeleteAsync(Guid id);
}