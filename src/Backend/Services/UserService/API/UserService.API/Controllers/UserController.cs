using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.UseCases.Commands.AddRolesCommand;
using UserService.Application.UseCases.Commands.AddRolesToUserCommand;
using UserService.Application.UseCases.Commands.LoginCommand;
using UserService.Application.UseCases.Commands.RegisterCommand;
using UserService.Application.UseCases.Queries.GetUserClaimsQuery;

namespace UserService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody]LoginCommand loginCommand)
    {
        var result = await _mediator.Send(loginCommand);
        return Ok(result);
    }
    
    [HttpPost("signup")]
    public async Task<ActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        var result = await _mediator.Send(registerCommand);
        return Ok(result);
    }
    
    [HttpGet("claims/{userId}")]
    public async Task<IActionResult> GetUserClaims(string userId)
    {
        var command = new GetUserClaimsQuery { UserId = userId };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("add-roles")]
    public async Task<IActionResult> AddRoles([FromBody] AddRolesCommand addRolesCommand)
    {
        var result = await _mediator.Send(addRolesCommand);
        return Ok(result);
    }
    
    [HttpPost("add-roles-to-user")]
    public async Task<IActionResult> AddRolesToUser([FromBody] AddRolesToUserCommand addRolesToUserCommand)
    {
        var result = await _mediator.Send(addRolesToUserCommand);
        return Ok(result);
    }
}