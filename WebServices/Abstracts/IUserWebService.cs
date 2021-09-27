using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharedData.DTO;

namespace WebServices.Abstracts
{
    public interface IUserWebService
    {
        public ActionResult<UserDto> Get(Guid id);
        public ActionResult<List<UserDto>> GetUserList();
        public ActionResult Create(UserDto request);
        public ActionResult Update(Guid id, UserDto request);
        public ActionResult Delete(Guid id);
    }
}