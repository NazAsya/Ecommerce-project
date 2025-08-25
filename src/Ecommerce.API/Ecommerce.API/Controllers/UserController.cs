using AutoMapper;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
  private readonly IUserService _userService;
  private readonly IMapper _mapper;
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

   // READ - GET By Id
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();
       
        var userDto = _mapper.Map<UserDto>(user);
        return Ok(userDto);
    }
    [HttpGet("byemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null) return NotFound();
        
        var usersDto = _mapper.Map<UserDto>(user); // DTO'ya dönüşüm
        return Ok(usersDto);

    }
    // READ - GET All
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users); 
        return Ok(usersDto);
    }

    // CREATE - POST
    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDto userCreateDto)
    {
      var user = _mapper.Map<User>(userCreateDto); // DTO → Entity
      await _userService.AddUserAsync(user);
      var userDto = _mapper.Map<UserDto>(user); // Entity → DTO
      return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
    }

    // UPDATE - PUT
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutUser(Guid id, UserCreateDto userUpdateDto)
    {
        var existingUser = await _userService.GetUserByIdAsync(id);
        if (existingUser == null) return NotFound();
        
        _mapper.Map(userUpdateDto, existingUser);
        await _userService.UpdateUserAsync(existingUser);
        var updatedUserDto = _mapper.Map<UserDto>(existingUser);
        return Ok("User updated successfully.");
    }

    // DELETE - DELETE
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var existingUser = await _userService.GetUserByIdAsync(id);
        if (existingUser == null)
            return NotFound();

        await _userService.DeleteUserAsync(id);
        return Ok("User deleted successfully.");
    }

}

