using Application.Services;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Login;

public class LoginRequestHandler : IRequestHandler<LoginRequest, UserDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _tokenService;

    public LoginRequestHandler(UserManager<AppUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    public async Task<UserDto> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.LoginDto.Email);

        if (user == null) 
            throw new NotFoundException(nameof(AppUser),user);
 
        var result = await _userManager.CheckPasswordAsync(user, request.LoginDto.Password);
        
        var token = _tokenService.CreateToken(user);
        
        return new UserDto
        {
            DisplayName = user.DisplayName,
            Image = null,
            Token = token,
            Username = user.UserName
        };
    }
}