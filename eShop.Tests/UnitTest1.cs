using Application.Features.Auth.Register;
using Application.Services;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Identity;
using eShop.Tests.Mocks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using WebAPI.Controllers;

namespace eShop.Tests;

public class UnitTest1
{
    private readonly Mock<UserManager<AppUser>> _userManagerMock;
    private readonly Mock<TokenService> _tokenServiceMock;
    private readonly Mock<IMediator> _mediatorMock;

    public UnitTest1()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        _userManagerMock = MockUserManager.GetMockUserManager<AppUser>();
        _tokenServiceMock = new Mock<TokenService>(configuration);
        _mediatorMock = new Mock<IMediator>();
    }
    
    [Fact]
    public void Handler_ShouldThrowException_WhenEmailIsNotUnique()
    {
        // Arrange

        var request = new RegisterRequest(new RegisterDto
        {
            DisplayName = "",
            Email = "test@mail.com",
            Password = "Pa$$w0rd",
            UserName = "test"
        });
        
        var handler = new RegisterRequestHandler(_userManagerMock.Object, _tokenServiceMock.Object);

        // Act & Assert
        Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public void Handler_ShouldThrowException_WhenPasswordIsNotValid()
    {
        // Arrange
        var request = new RegisterRequest(new RegisterDto
        {
            DisplayName = "",
            Email = "test123@mail.com",
            Password = "Pa$$wrd",
            UserName = "test"
        });
        var handler = new RegisterRequestHandler(_userManagerMock.Object, _tokenServiceMock.Object);
        
        // Act & Assert
        Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(request, CancellationToken.None));
    }
}