using Application.Services;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Register;

public class RegisterRequestHandler : IRequestHandler<RegisterRequest,UserDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _tokenService;

    public RegisterRequestHandler(UserManager<AppUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    public async Task<UserDto> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        if(await _userManager.Users.AnyAsync(x => x.Email == request.RegisterDto.Email, cancellationToken: cancellationToken))
            throw new BadRequestException("Email already exists");

        var user = new AppUser
        {
            DisplayName = request.RegisterDto.DisplayName,
            Email = request.RegisterDto.Email,
            UserName = request.RegisterDto.UserName
        };
        var result = await _userManager.CreateAsync(user, request.RegisterDto.Password);
        if (result.Succeeded)
        {
            var token = _tokenService.CreateToken(user);
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = null,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName
            };
        }
        throw new BadRequestException(String.Join('\n',result.Errors.Select(x => x.Description)));
    }
}