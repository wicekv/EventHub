using EventHub.Application.Commands.Events.JoinTheEvent;
using EventHub.Application.Queries.Events;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using EventId = EventHub.Core.ValueObjects.Events.EventId;

namespace EventHub.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class RegistrationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegistrationsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{id:guid}")]
    [SwaggerOperation("Attach to an existing event")]
    public async Task<IActionResult> RegisterUserForEvent(Guid id, CancellationToken cancellationToken)
    {
        var command = new RegisterUserForEventCommand(id);
        var result = await _mediator.Send(command, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet]
    [SwaggerOperation("Get the events to which you are registered")]
    public async Task<IActionResult> GetRegistredEvents(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetRegisteredEventsQuery(), cancellationToken);
        
        return Ok(result);
    }
}