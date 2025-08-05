using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Speakers.Core.Exceptions;

internal class SpeakerNotFoundException(Guid id) : ConfabException($"Speaker with ID '{id}' was not found.");