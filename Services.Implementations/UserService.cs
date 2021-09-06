using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstracts;
using Services.Abstracts;
using Services.Implementations.Validation;
using SharedData.DTO;
using SharedData.Locale;
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

        public async Task<ActionResult> Add(UserDto userModel)
        {
            var validation = new UserModelValidation(userModel, _repository.GetByEmail(userModel.Email));
            if (validation.RequiredFieldsAreNotFilled)
            {
                return ResponseFactory.FailResponse(ServiceErrors.RequiredFieldsAreNotFilled);
            }

            if (validation.UserAlreadyExists)
            {
                return ResponseFactory.FailResponse(ServiceErrors.UserWithThisEmailAlreadyExists);
            }

            _repository.Add(userModel.Map(model => new User
            {
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                MiddleName = userModel.MiddleName
            }));
            try
            {
                _repository.SaveChanges();
            }
            catch(Exception e)
            {
                //log exception
                return ResponseFactory.FailResponse(ServiceErrors.DatabaseIsNotResponding);
            }

            return new OkResult();
        }

        public async Task<ActionResult> Update(Guid id, UserDto userModel)
        {
            if (_repository.GetById(id) is null)
            {
                return new NotFoundResult();
            }

            var validation = new UserModelValidation(userModel, _repository.GetByEmail(userModel.Email));
            
            if (validation.RequiredFieldsAreNotFilled)
            {
                return ResponseFactory.FailResponse(ServiceErrors.RequiredFieldsAreNotFilled);
            }

            if (validation.UserAlreadyExists)
            {
                return ResponseFactory.FailResponse(ServiceErrors.UserWithThisEmailAlreadyExists);
            }

            var existingUser = _repository.GetById(id);
            (existingUser.Email, existingUser.FirstName, existingUser.LastName, existingUser.MiddleName) =
                (userModel.Email, userModel.FirstName, userModel.LastName, userModel.MiddleName);

            try
            {
                _repository.Update(existingUser);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                //log exception
                return ResponseFactory.FailResponse(ServiceErrors.DatabaseIsNotResponding);
            }

            return new OkResult();
        }

        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var user = _repository.GetById(id);
            if (user is null) return new StatusCodeResult((int)HttpStatusCode.NoContent);

            return user.Map(u => new UserDto(u.Email, u.FirstName, u.LastName, u.MiddleName));
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var user = _repository.GetById(id);
            if (user is null) return new NotFoundResult();

            try
            {
                _repository.Delete(user);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                //log exception
                return ResponseFactory.FailResponse(ServiceErrors.DatabaseIsNotResponding);
            }

            return new OkResult();
        }

        public async Task<List<UserDto>> GetUserList()
        {
            return _repository
                .GetUserList()
                .ToList()
                .Map(u => 
                new UserDto(
                    u.Email, 
                    u.FirstName,
                    u.LastName, 
                    u.MiddleName
                ));
        }
    }
}