using Domain.DTOs;
using MediatR;

namespace Application.Features.Auth.GetUser;

public record GetUserRequest() : IRequest<UserDto>;