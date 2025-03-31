using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.User.Commands.AddRolesCommand;
using UserService.Application.User.Commands.AddRolesToUserCommand;
using UserService.Application.User.Commands.LoginCommand;
using UserService.Application.User.Commands.RegisterCommand;
using UserService.Application.User.Queries.GetByUserNameQuery;
using UserService.Application.User.Queries.GetUserByIdQuery;
using UserService.Application.User.Queries.GetUserClaimsQuery;

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
    
    [HttpGet("{userId}/claims")]
    public async Task<IActionResult> GetClaims(string userId)
    {
        var command = new GetUserClaimsQuery { UserId = userId };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(string userId)
    {
        var query = new GetUserByIdQuery { UserId = userId};
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("get-by-username/{userName}")]
    public async Task<IActionResult> GetByUserName(string userName)
    {
        var query = new GetByUserNameQuery { UserName = userName };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update()
    {
        return Ok();
    }
    
    [HttpPost("roles/add")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> AddRoles([FromBody] AddRolesCommand addRolesCommand)
    {
        var result = await _mediator.Send(addRolesCommand);
        return Ok(result);
    }
    
    [HttpPost("roles/add-to-user")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> AddRolesToUser([FromBody] AddRolesToUserCommand addRolesToUserCommand)
    {
        var result = await _mediator.Send(addRolesToUserCommand);
        return Ok(result);
    }
}