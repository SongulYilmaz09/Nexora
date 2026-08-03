using Nexora.Application.Features.Tasks.Delete;
using Nexora.Application.Features.Tasks.GetById;
using Nexora.Application.Features.Tasks.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexora.Application.Features.Tasks.Create;
using Nexora.Application.Features.Tasks.Update;
namespace Nexora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskCommand command)
    {
        var taskId = await _mediator.Send(command);

        return Ok(new
        {
            Id = taskId,
            Message = "Task created successfully."
        });
    }
    [HttpGet]
public async Task<IActionResult> GetAll()
{
    var tasks = await _mediator.Send(new GetAllTasksQuery());

    return Ok(tasks);
}
[HttpGet("{id:guid}")]
public async Task<IActionResult> GetById(Guid id)
{
    var task = await _mediator.Send(new GetTaskByIdQuery(id));

    if (task is null)
        return NotFound();

    return Ok(task);
}
[HttpPut("{id:guid}")]
public async Task<IActionResult> Update(Guid id, UpdateTaskCommand command)
{
    command.Id = id;

    await _mediator.Send(command);

    return NoContent();
}
[HttpDelete("{id:guid}")]
public async Task<IActionResult> Delete(Guid id)
{
    await _mediator.Send(new DeleteTaskCommand(id));

    return NoContent();
}
}