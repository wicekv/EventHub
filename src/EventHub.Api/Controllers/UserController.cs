using EventHub.Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        
        return Ok(result);
    }
}