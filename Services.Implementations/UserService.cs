using System;
using System.Reflection;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstracts;
using Services.Abstracts;
using SharedData.DTO;
using SharedData.Exceptions;
using Utilities;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<ActionResult> Add(UserDto userModel)
        {
            if (userModel.FirstName.IsNullOrEmpty()) return new 
        }

        public Task<ActionResult> Update(Guid id, UserDto userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var user = _repository.GetById(id);
            if (user is null) return new StatusCodeResult(204);

            return user.Map(u => new UserDto(u.Email, u.FirstName, u.LastName, u.MiddleName));
        }

        public Task<ActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}