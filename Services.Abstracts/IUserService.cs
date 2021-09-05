using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedData.DTO;

namespace Services.Abstracts
{
    public interface IUserService
    {
        public Task<ActionResult> Add(UserDto userModel);
        public Task<ActionResult> Update(Guid id, UserDto userModel);
        public Task<ActionResult<UserDto>> Get(Guid id);
        public Task<ActionResult> Delete(Guid id);
    }
}