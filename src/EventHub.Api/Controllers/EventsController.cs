using EventHub.Application.Commands.Events.CreateEvents;
using EventHub.Application.Commands.Events.UpdateTitle;
using EventHub.Application.Queries.Events;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventHub.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [SwaggerOperation("Create event")]
    public async Task<IActionResult> Create([FromBody] CreateEventCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPatch("{id:guid}")]
    [SwaggerOperation("Rename title for event")]
    public async Task<IActionResult> UpdateTitle([FromRoute] Guid id, [FromBody] UpdateEventTitleCommand command, 
        CancellationToken cancellationToken)
    {
        command = command with { EventId = id };
        
        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }
    
    [HttpGet]
    [SwaggerOperation("Get created events")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserEventsQuery(),cancellationToken);
        
        return Ok(result);
    }
}