using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Users.Core.Exceptions;

internal class EmailInUserException() : ConfabException("Email is already in use.");