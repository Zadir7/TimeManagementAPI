using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;
using SharedData.DTO;
using WebServices.Abstracts;

namespace WebServices
{
    public class UserWebService : IUserWebService
    {
        private readonly IUserService _userService;
        
        public UserWebService(IUserService userService)
        {
            _userService = userService;
        }
        
        public ActionResult<UserDto> Get(Guid id) => _userService.Get(id).AsActionResult();

        public ActionResult<List<UserDto>> GetUserList() => _userService.GetUserList().AsActionResult();

        public ActionResult Create(UserDto request) => _userService.Add(request).AsActionResult();

        public ActionResult Update(Guid id, UserDto request) => _userService.Update(id, request).AsActionResult();

        public ActionResult Delete(Guid id) => _userService.Delete(id).AsActionResult();
    }
}