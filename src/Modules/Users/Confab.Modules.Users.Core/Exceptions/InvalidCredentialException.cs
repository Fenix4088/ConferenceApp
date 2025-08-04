using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Users.Core.Exceptions;

internal class InvalidCredentialsException() : ConferenceAppException("Invalid credentials.");