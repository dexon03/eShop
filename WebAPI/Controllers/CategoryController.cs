using Application.Features.Categories.Create;
using Application.Features.Categories.Delete;
using Application.Features.Categories.Edit;
using Application.Features.Categories.GetAll;
using Application.Features.Categories.Get;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoryController : Controller
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAllCategories()
    {
        return Ok(await _mediator.Send(new GetAllCategoryRequest()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(Guid id)
    {
        try
        {
            var category = await _mediator.Send(new GetCategoryRequest(id));
            return Ok(category);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e); 
            return NotFound();
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(Category category)
    {
        try
        {
            await _mediator.Send(new CreateCategoryCommand(category));
            return Ok();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditCategory(Guid id,Category category)
    {
        category.Id = id;
        try
        {
            await _mediator.Send(new EditCategoryCommand(category));
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }

}