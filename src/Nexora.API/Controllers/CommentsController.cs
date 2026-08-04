using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.Comments.Create;
using Nexora.Application.Features.Comments.GetByTask;
namespace Nexora.API.Controllers;
using Nexora.Application.Features.Comments.Update;
using Nexora.Application.Features.Comments.Delete;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new
        {
            Id = id,
            Message = "Comment created successfully."
        });
    }
    [HttpGet("task/{taskId}")]
public async Task<IActionResult> GetByTask(Guid taskId)
{
    var comments = await _mediator.Send(
        new GetCommentsByTaskQuery
        {
            TaskId = taskId
        });

    return Ok(comments);
}


[HttpPut("{id}")]
public async Task<IActionResult> Update(
    Guid id,
    UpdateCommentCommand command)
{
    command.Id = id;

    await _mediator.Send(command);

    return NoContent();
}


[HttpDelete("{id}")]
public async Task<IActionResult> Delete(Guid id)
{
    await _mediator.Send(new DeleteCommentCommand
    {
        Id = id
    });

    return NoContent();
}
}