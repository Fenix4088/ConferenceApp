using Confab.Modules.Speakers.Core.DTO;

namespace Confab.Modules.Speakers.Core.Services;

internal interface ISpeakersService
{
    Task AddAsync(SpeakerDto speakerDto);
    Task<SpeakerDto> GetAsync(Guid id);
    Task<IReadOnlyList<SpeakerDto>> GetAllAsync();
    Task UpdateAsync(SpeakerDto speakerDto);
    Task DeleteAsync(Guid id);
}