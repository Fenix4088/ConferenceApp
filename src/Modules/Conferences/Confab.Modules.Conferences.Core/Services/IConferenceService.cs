using Confab.Modules.Conferences.Core.DTO;

namespace Confab.Modules.Conferences.Core.Services;

internal interface IConferenceService
{
    Task AddAsync(ConferenceDetailsDto conferenceDetailsDto);
    Task<ConferenceDetailsDto> GetAsync(Guid id);
    Task<IReadOnlyList<ConferenceDto>> GetAllAsync();
    Task UpdateAsync(ConferenceDetailsDto conferenceDetailsDto);
    Task DeleteAsync(Guid id);
}