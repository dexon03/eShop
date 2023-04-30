using Application.Features.Auth.GetUser;
using Application.Features.Auth.Login;
using Application.Features.Auth.Register;
using Domain.DTOs;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _mediator.Send(new LoginRequest(loginDto));

        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        var user = await _mediator.Send(new RegisterRequest(registerDto));

        return Ok(user);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUser()
    {
        return Ok( await _mediator.Send(new GetUserRequest()));
    }
}