using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Users.Core.Exceptions;

internal class EmailInUserException() : ConferenceAppException("Email is already in use.");