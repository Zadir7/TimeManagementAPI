using System;
using System.Collections.Generic;
using System.Linq;
using Repositories.Abstracts;
using Services.Abstracts;
using SharedData.DTO;
using SharedData.Locale;
using SharedData.Models;
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

        public ServiceResult Add(UserDto userModel)
        {
            //TODO: Reimplement model validation

            _repository.Add(userModel.Map(model => new Data.Entities.User
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
                return new FailedResult(ServiceErrors.DatabaseIsNotResponding);
            }

            return new SuccessfulResult();
        }

        public ServiceResult Update(Guid id, UserDto userModel)
        {
            if (_repository.GetById(id) is null)
            {
                return new FailedResult(ServiceErrors.UserDoesNotExist);
            }

            //TODO: Reimplement model validation

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
                return new FailedResult(ServiceErrors.DatabaseIsNotResponding);
            }

            return new SuccessfulResult();
        }

        public ServiceResult<UserDto> Get(Guid id)
        {
            var user = _repository.GetById(id);
            if (user is null) return new FailedResult<UserDto>(ServiceErrors.UserDoesNotExist);

            return new SuccessfulResult<UserDto>(user.Map(u => new UserDto(u.Email, u.FirstName, u.LastName, u.MiddleName)));
        }

        public ServiceResult Delete(Guid id)
        {
            var user = _repository.GetById(id);
            if (user is null) return new FailedResult(ServiceErrors.UserDoesNotExist);

            try
            {
                _repository.Delete(user);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                //log exception
                return new FailedResult(ServiceErrors.DatabaseIsNotResponding);
            }

            return new SuccessfulResult();
        }

        public ServiceResult<List<UserDto>> GetUserList()
        {
            return new SuccessfulResult<List<UserDto>>(
                _repository
                .GetUserList()
                .ToList()
                .Map(u => 
                new UserDto(
                    u.Email, 
                    u.FirstName,
                    u.LastName, 
                    u.MiddleName
                ))
            );
        }
    }
}