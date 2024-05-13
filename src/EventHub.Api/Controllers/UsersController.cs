using EventHub.Application.Commands.Users.CreateUser;
using EventHub.Application.Commands.Users.LoginUser;
using EventHub.Application.DTO;
using EventHub.Application.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventHub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenStorage _tokenStorage;

    public UsersController(IMediator mediator, ITokenStorage tokenStorage)
    {
        _mediator = mediator;
        _tokenStorage = tokenStorage;
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    [SwaggerOperation("Login user and return the JSON Web Token")]
    public async Task<ActionResult<JwtDto>> Post([FromBody] LoginUserCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        
        return _tokenStorage.Get();
    }
    
    [HttpPost]
    [SwaggerOperation("Create user account")]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        
        return Ok(result);
    }
}