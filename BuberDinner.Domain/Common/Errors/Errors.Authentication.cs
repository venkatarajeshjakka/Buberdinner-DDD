using ErrorOr;

namespace BuberDinner.Domain.Common;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InValidCredentials = Error.Validation(
            code: "Auth.InvalidCred",
            description: "Invalid Credentials.");
    }
}