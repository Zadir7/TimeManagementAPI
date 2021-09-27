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
        
        public ActionResult<UserDto> Get(Guid id)
        {
            return _userService.Get(id);
        }

        public ActionResult<List<UserDto>> GetUserList()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create(UserDto request)
        {
            throw new NotImplementedException();
        }

        public ActionResult Update(Guid id, UserDto request)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}