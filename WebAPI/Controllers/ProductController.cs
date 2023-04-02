using Application.Features.Products.Create;
using Application.Features.Products.Delete;
using Application.Features.Products.Edit;
using Application.Features.Products.Get;
using Application.Features.Products.GetAll;
using Domain.Entities;
using FluentValidation;
using MediatR;
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
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetProductQuery(id));
            return Ok(result);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        try
        {
            await _mediator.Send(new CreateProductCommand(product));
            return StatusCode(201);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
            return BadRequest();
        }
        catch (ValidationException e)
        {
            Console.WriteLine(e.Message);
            return ValidationProblem();
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Product product)
    {
        product.Id = id;
        try
        {
            await _mediator.Send(new EditProductCommand(product));
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
        catch (ValidationException e)
        {
            Console.WriteLine(e.Message);
            return ValidationProblem(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }
}