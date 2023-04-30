using Application.Features.Products.Create;
using Application.Features.Products.Delete;
using Application.Features.Products.Edit;
using Application.Features.Products.Get;
using Application.Features.Products.GetAll;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductQuery());
        return Ok(result);
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetProductQuery(id));
        return Ok(result);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _mediator.Send(new CreateProductCommand(product));
        return StatusCode(201);
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Product product)
    {
        await _mediator.Send(new EditProductCommand(product));
        return Ok(); 
    }
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return Ok();
    }
}