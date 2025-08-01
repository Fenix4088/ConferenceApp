using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Speakers.Core.Exceptions;

internal class SpeakerNotFoundException(Guid id) : ConferenceAppException($"Speaker with ID '{id}' was not found.");