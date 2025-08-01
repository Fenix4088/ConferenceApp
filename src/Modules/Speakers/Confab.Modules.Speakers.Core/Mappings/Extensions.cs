using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Mappings;

internal static class Extensions
{

    public static SpeakerDto AsDto(this Speaker speaker)
    {
        return new SpeakerDto
        {
            Id = speaker.Id,
            Email = speaker.Email,
            FullName = speaker.FullName,
            Bio = speaker.Bio,
            AvatarUrl = speaker.AvatarUrl
        };
    }
    
    public static Speaker AsEntity(this SpeakerDto speakerDto)
    {
        return new Speaker
        {
            Id = speakerDto.Id,
            Email = speakerDto.Email,
            FullName = speakerDto.FullName,
            Bio = speakerDto.Bio,
            AvatarUrl = speakerDto.AvatarUrl
        };
    }
}