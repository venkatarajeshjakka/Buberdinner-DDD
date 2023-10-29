using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicatieEmail = Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already exisits.");
    }
}