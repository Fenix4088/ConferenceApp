using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Speakers.Core.Exceptions;

internal class SpeakerAlreadyExistException(Guid id) : ConferenceAppException($"Speaker with id '{id}' already exists.");