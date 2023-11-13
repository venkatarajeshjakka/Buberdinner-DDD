
using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(a => a.Email)
        .NotEmpty()
        .EmailAddress();

        RuleFor(a => a.Password)
        .NotEmpty();
    }
}