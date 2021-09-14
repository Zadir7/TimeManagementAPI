using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;
using SharedData.DTO;

namespace TimeManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync(Guid id)
        {
            return await _userService.Get(id);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUserListAsync()
        {
            return await _userService.GetUserList();
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserDto request)
        {
            return await _userService.Add(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] UserDto request)
        {
            return await _userService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        { 
            return await _userService.Delete(id);
        }
    }
}
