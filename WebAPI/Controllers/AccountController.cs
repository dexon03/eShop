using Application.Features.Auth.Login;
using Application.Features.Auth.Register;
using Domain.DTOs;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _mediator.Send(new LoginRequest(loginDto));

        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        var user = await _mediator.Send(new RegisterRequest(registerDto));

        return Ok(user);
    }
}