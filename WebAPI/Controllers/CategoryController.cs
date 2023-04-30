using Application.Features.Categories.Create;
using Application.Features.Categories.Delete;
using Application.Features.Categories.Edit;
using Application.Features.Categories.GetAll;
using Application.Features.Categories.Get;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize]
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
        return Ok(await _mediator.Send(new GetAllCategoryQuery()));
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<Category>> GetCategory(Guid id)
    {
        var category = await _mediator.Send(new GetCategoryQuery(id));
        return Ok(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(Category category)
    {
            await _mediator.Send(new CreateCategoryCommand(category));
            return Ok();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id));
        return Ok();return NotFound();
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> EditCategory(Guid id,Category category)
    {
        await _mediator.Send(new EditCategoryCommand(category));
        return Ok();
    }

}