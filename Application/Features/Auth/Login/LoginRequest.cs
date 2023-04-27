using Domain.DTOs;
using MediatR;

namespace Application.Features.Auth.Login;

public record LoginRequest(LoginDto LoginDto) : IRequest<UserDto>;