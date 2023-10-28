using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;
using OneOf;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRespository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRespository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public OneOf<AuthenticationResult, DuplicateEmailError> Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {

        //Check if user already exists

        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return new DuplicateEmailError();
        }
        //Create user ( generate unique ID)

        var user = new User()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password
        };

        _userRepository.Add(user);
        //Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}