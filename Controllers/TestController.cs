namespace dotnet_6_crud_api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using dotnet_6_crud_api.Models.Users;
using dotnet_6_crud_api.Services;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;

    public TestController(
        IUserService userService,
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("test")]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }


    
}