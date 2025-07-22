using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Entities;
using Confab.Modules.Conferences.Core.Exceptions;
using Confab.Modules.Conferences.Core.Policies;
using Confab.Modules.Conferences.Core.Repositories;

namespace Confab.Modules.Conferences.Core.Services;

internal class HostService(IHostRepository hostRepository, IHostDeletionPolicy hostDeletionPolicy) : IHostService
{
    public async Task AddAsync(HostDto hostDto)
    {
        await hostRepository.AddAsync(new Host()
        {
            Id = Guid.NewGuid(),
            Name = hostDto.Name,
            Description = hostDto.Description
        });
    }

    public async Task<HostDetailsDto> GetAsync(Guid id)
    {
        var host = await hostRepository.GetAsync(id);

        if (host is null) return null;
        
        var dto = Map<HostDetailsDto>(host);
        dto.Conferences = host.Conferences.Select(conference => new ConferenceDto()
        {
            Id = conference.Id,
            Name = conference.Name,
            HostId = conference.HostId,
            HostName = conference.Host.Name,
            Location = conference.Location,
            LogoUrl = conference.LogoUrl,
            ParticipantsLimit = conference.ParticipantsLimit,
            From = conference.From,
            To = conference.To
        }).ToList();
        
        return dto;
    }

    public async Task<IReadOnlyList<HostDto>> GetAllAsync()
    {
        var hosts =  await hostRepository.GetAllAsync();

        return hosts.Select(Map<HostDto>).ToList();
    }

    public async Task UpdateAsync(HostDetailsDto hostDetailsDto)
    {
        var host = await hostRepository.GetAsync(hostDetailsDto.Id);
        
        if (host == null)
        {
            throw new HostNotFoundException(hostDetailsDto.Id);
        }
        
        host.Name = hostDetailsDto.Name;
        host.Description = hostDetailsDto.Description;
        await hostRepository.UpdateAsync(host);
    }

    public async Task DeleteAsync(Guid id)
    {
        var host = await hostRepository.GetAsync(id);
        
        if (host == null)
        {
            throw new HostNotFoundException(id);
        }
        
        if (!await hostDeletionPolicy.CanDeleteAsync(host))
        {
            throw new CanNotDeleteHostException(id);
        }
        
        await hostRepository.DeleteAsync(id);
    }
    
    private static T Map<T>(Host host) where T : HostDto, new()
    {
        return new T
        {
            Id = host.Id,
            Name = host.Name,
            Description = host.Description
        };
    }
}