using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Entities;
using Confab.Modules.Conferences.Core.Exceptions;
using Confab.Modules.Conferences.Core.Policies;
using Confab.Modules.Conferences.Core.Repositories;

namespace Confab.Modules.Conferences.Core.Services;

internal class ConferenceService(
    IConferenceRepository conferenceRepository,
    IHostRepository hostRepository,
    IConferenceDeletionPolicy conferenceDeletionPolicy
    ) : IConferenceService
{
    public async Task AddAsync(ConferenceDetailsDto conferenceDetailsDto)
    {
        if(await hostRepository.GetAsync(conferenceDetailsDto.HostId) is null) 
        {
            throw new HostNotFoundException(conferenceDetailsDto.HostId);
        }

        await conferenceRepository.AddAsync(new Conference()
        {
            Id = Guid.NewGuid(),
            HostId = conferenceDetailsDto.HostId,
            Name = conferenceDetailsDto.Name,
            Description = conferenceDetailsDto.Description,
            Location = conferenceDetailsDto.Location,
            LogoUrl = conferenceDetailsDto.LogoUrl,
            ParticipantsLimit = conferenceDetailsDto.ParticipantsLimit,
            From = conferenceDetailsDto.From,
            To = conferenceDetailsDto.To
        });
    }

    public async Task<ConferenceDetailsDto?> GetAsync(Guid id)
    {
        var conference = await conferenceRepository.GetAsync(id);
        if (conference is null)
        {
            return null;
        }

        var dto = Map<ConferenceDetailsDto>(conference);
        dto.Description = conference.Description;
        
        return dto;
    }

    public async Task<IReadOnlyList<ConferenceDto>> GetAllAsync()
    {
        return (await conferenceRepository.GetAllAsync())
            .Select(Map<ConferenceDto>).ToList();
    }

    public async Task UpdateAsync(ConferenceDetailsDto conferenceDetailsDto)
    {
        var conference = await conferenceRepository.GetAsync(conferenceDetailsDto.Id);
        
        if (conference is null)
        {
            throw new ConferenceNotFoundException(conferenceDetailsDto.Id);
        }
        
        conference.Name = conferenceDetailsDto.Name;
        conference.Description = conferenceDetailsDto.Description;
        conference.Location = conferenceDetailsDto.Location;
        conference.LogoUrl = conferenceDetailsDto.LogoUrl;
        conference.ParticipantsLimit = conferenceDetailsDto.ParticipantsLimit;
        conference.From = conferenceDetailsDto.From;
        conference.To = conferenceDetailsDto.To;
        
        await conferenceRepository.UpdateAsync(conference);
    }

    public async Task DeleteAsync(Guid id)
    {
        var conference = await conferenceRepository.GetAsync(id);
        
        if (conference is null)
        {
            throw new ConferenceNotFoundException(id);
        }
        
        if (await conferenceDeletionPolicy.CanDeleteAsync(conference) is false)
        {
            throw new CanNotDeleteConferenceException(id);
        }
        
        await conferenceRepository.DeleteAsync(id);
        
    }
    
    
    private T Map<T>(Conference conference) where T : ConferenceDto, new()
    {
        return new T
        {
            Id = conference.Id,
            HostId = conference.HostId,
            HostName = conference.Host?.Name,
            Name = conference.Name,
            Location = conference.Location,
            LogoUrl = conference.LogoUrl,
            ParticipantsLimit = conference.ParticipantsLimit,
            From = conference.From,
            To = conference.To
        };
    }
}