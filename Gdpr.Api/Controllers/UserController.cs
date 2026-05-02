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
        var userId = _userService.CreateUser(request);

        var response = ApiResponse<UserResponseDto>.SuccessResponse(
            new UserResponseDto{ UserId = userId },
            "User created successfully"
        );

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
       var result = await _userService.GetPagedAsync(request.PageNumber, request.PageSize);

       return Ok(ApiResponse<PaginatedResponse<UserResponseDto>>.SuccessResponse(result));
    }

    [HttpPut("{id}")]
public async Task<IActionResult> Update(Guid id, UpdateUserRequest request)
{
    await _userService.UpdateAsync(id, request);

     return Ok(ApiResponse<string>.SuccessResponse(null, "User updated successfully"));
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteAsync(id);

        return Ok(ApiResponse<string>.SuccessResponse(null, "User deleted successfully"));
    }
}