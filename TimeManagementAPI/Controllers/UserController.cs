using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharedData.DTO;
using WebServices.Abstracts;

namespace TimeManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserWebService _userService;

        public UserController(IUserWebService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(Guid id)
        {
            return _userService.Get(id);
        }
        
        [HttpGet]
        public ActionResult<List<UserDto>> GetUserList()
        {
            return _userService.GetUserList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDto request)
        {
            return _userService.Create(request);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] UserDto request)
        {
            return _userService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        { 
            return _userService.Delete(id);
        }
    }
}
