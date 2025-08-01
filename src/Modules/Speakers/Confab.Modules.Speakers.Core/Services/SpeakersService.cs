using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Exceptions;
using Confab.Modules.Speakers.Core.Mappings;
using Confab.Modules.Speakers.Core.Repositories;

namespace Confab.Modules.Speakers.Core.Services;

internal class SpeakersService(ISpeakersRepository speakersRepository) : ISpeakersService
{
    public async Task AddAsync(SpeakerDto speakerDto)
    {
        if(await speakersRepository.ExistsAsync(speakerDto.Id))
        {
            throw new SpeakerAlreadyExistException(speakerDto.Id);
        }
        
        await speakersRepository.AddAsync(new Speaker
        {
            Email = speakerDto.Email,
            FullName = speakerDto.FullName,
            Bio = speakerDto.Bio,
            AvatarUrl = speakerDto?.AvatarUrl,
        });
    }

    public async Task<SpeakerDto> GetAsync(Guid id)
    {
        var speaker = await VerifySpeaker(id);
        
        return speaker.AsDto();
    }

    public async Task<IReadOnlyList<SpeakerDto>> GetAllAsync()
    {
        return (await speakersRepository.GetAllAsync()).Select(speaker => speaker.AsDto()).ToList();
    }

    public async Task UpdateAsync(SpeakerDto speakerDto)
    {
        var speaker = await VerifySpeaker(speakerDto.Id);
        
        speaker.Email = speakerDto.Email;
        speaker.FullName = speakerDto.FullName;
        speaker.Bio = speakerDto.Bio;
        speaker.AvatarUrl = speakerDto.AvatarUrl;
        
        await speakersRepository.UpdateAsync(speaker);
    }

    public async Task DeleteAsync(Guid id)
    {
        var speaker = await VerifySpeaker(id);
        
        await speakersRepository.DeleteAsync(speaker);
    }
    
    private async Task<Speaker> VerifySpeaker(Guid id)
    {
        var speaker =  await speakersRepository.GetAsync(id);

        if (speaker is null)
        {
            throw new SpeakerNotFoundException(id);
        }
        
        return speaker;
    }
}