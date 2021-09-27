using System;
using System.Collections.Generic;
using SharedData.DTO;
using SharedData.Models;

namespace Services.Abstracts
{
    public interface IUserService
    {
        public ServiceResult Add(UserDto userModel);
        public ServiceResult Update(Guid id, UserDto userModel);
        public ServiceResult<UserDto> Get(Guid id);
        public ServiceResult Delete(Guid id);
        public ServiceResult<List<UserDto>> GetUserList();
    }
}