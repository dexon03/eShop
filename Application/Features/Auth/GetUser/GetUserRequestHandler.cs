using System.Security.Claims;
using Application.Services;
using Domain.DTOs;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.GetUser;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest,UserDto>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _tokenService;

    public GetUserRequestHandler(IHttpContextAccessor httpContextAccessor, 
        UserManager<AppUser> userManager, 
        TokenService tokenService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _tokenService = tokenService;
    }
    public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(
            _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email));
        
        return new UserDto
        {
            DisplayName = user.DisplayName,
            Image = null,
            Token = _tokenService.CreateToken(user),
            Username = user.UserName
        };
    }
}