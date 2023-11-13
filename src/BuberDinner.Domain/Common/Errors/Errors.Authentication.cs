using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InValidCredentials = Error.Validation(
            code: "Auth.InvalidCred",
            description: "Invalid Credentials.");
    }
}