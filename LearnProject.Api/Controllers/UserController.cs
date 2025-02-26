using LearnProject.Api.Helpers;
using LearnProject.Service.DTOs;
using LearnProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userService.RetrieveAllAsync()
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userService.RetrieveByIdAsync(id)
        });
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id,[FromBody] UserForUpdateDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userService.ModifyAsync(id, dto)
        });
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] UserForCreationDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userService.AddAsync(dto)
        });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await userService.RemoveAsync(id)
        });
    }

}
