using BuberDinner.Application.Common.Services.Authentication.Queries;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(IAuthenticationCommandService authenticationCommandService,
    IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        ErrorOr<AuthenticationResult> registeredResult = _authenticationCommandService.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password);

        return registeredResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors));

    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                                authResult.User.Id,
                                authResult.User.FirstName,
                                authResult.User.LastName,
                                authResult.User.Email,
                                authResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(
            loginRequest.Email,
            loginRequest.Password);

        return authResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors));
    }

}