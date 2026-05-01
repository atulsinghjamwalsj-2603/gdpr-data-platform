using Microsoft.AspNetCore.Mvc;
using Gdpr.Application.DTOs;
using Gdpr.Application.Interfaces;

namespace Gdpr.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
public IActionResult CreateUser(CreateUserRequest request)
{
   if (!ModelState.IsValid)
    {
    return BadRequest(
        ApiResponse<string>.Failure("Invalid request data")
    );
    }

    var userId = _userService.CreateUser(request);

    var response = ApiResponse<object>.SuccessResponse(
        new { userId },
        "User created successfully"
    );

    return Ok(response);
}
}