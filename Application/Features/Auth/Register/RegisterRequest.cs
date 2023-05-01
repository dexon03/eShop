using Domain.DTOs;
using MediatR;

namespace Application.Features.Auth.Register;

public record RegisterRequest(RegisterDto RegisterDto) : IRequest<UserDto>;