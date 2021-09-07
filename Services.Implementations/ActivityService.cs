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
using SharedData.ViewModels;
using Utilities;

namespace Services.Implementations
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _repository;
        private readonly IUserRepository _userRepository;

        public ActivityService(IActivityRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }


        public async Task<ActionResult> Add(ActivityDto activityModel)
        {
            var validation = new ActivityModelValidation(activityModel);
            if (validation.RequiredFieldsAreNotFilled)
            {
                return ResponseFactory.FailResponse(ServiceErrors.RequiredFieldsAreNotFilled);
            }
            
            var user = _userRepository.GetById(activityModel.User.Id);
            if (user is null)
            {
                return ResponseFactory.FailResponse(ServiceErrors.UserDoesNotExist);
            }

            _repository.Add(activityModel.Map(model => new Activity
            {
                Date = model.Date,
                TimeSpent = TimeSpan.FromHours(model.HoursSpent),
                Note = model.Note,
                User = user
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

        public async Task<ActionResult> Update(Guid id, ActivityDto activityModel)
        {
            if (_repository.GetById(id) is null)
            {
                return new NotFoundResult();
            }

            var validation = new ActivityModelValidation(activityModel);
            if (validation.RequiredFieldsAreNotFilled)
            {
                return ResponseFactory.FailResponse(ServiceErrors.RequiredFieldsAreNotFilled);
            }

            var user = _userRepository.GetById(activityModel.User.Id);
            if (user is null)
            {
                return ResponseFactory.FailResponse(ServiceErrors.UserDoesNotExist);
            }

            var existingActivity = _repository.GetById(id);
            var newActivity = activityModel.Map(a =>
                new Activity
                {
                    Date = a.Date,
                    TimeSpent = TimeSpan.FromHours(a.HoursSpent),
                    Note = a.Note,
                    User = user
                }
            );

            (existingActivity.User, existingActivity.Date, existingActivity.TimeSpent, existingActivity.Note) =
                (newActivity.User, newActivity.Date, newActivity.TimeSpent, newActivity.Note);
            
            try
            {
                _repository.Update(existingActivity);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                //log exception
                return ResponseFactory.FailResponse(ServiceErrors.DatabaseIsNotResponding);
            }

            return new OkResult();
        }

        public async Task<ActionResult<ActivityDto>> Get(Guid id)
        {
            var activity = _repository.GetById(id);
            if (activity is null) return new StatusCodeResult((int)HttpStatusCode.NoContent);

            return activity.Map(a => new ActivityDto(
                a.User.Map(u => new UserVm(u.Id, $"{u.FirstName} + {u.LastName}")),
                a.TimeSpent.Hours,
                a.Date,
                a.Note)
            );
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var activity = _repository.GetById(id);
            if (activity is null) return new NotFoundResult();

            try
            {
                _repository.Delete(activity);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                //log exception
                return ResponseFactory.FailResponse(ServiceErrors.DatabaseIsNotResponding);
            }

            return new OkResult();
        }

        public async Task<List<ActivityDto>> GetUserActivitiesOnSelectedMonth(UserVm user, int month)
        {
            var result = _repository
                .GetActivitiesOfUserOnChosenMonth(user.Id, month)
                ?.ToList()
                ?.Map(a => new ActivityDto(user, a.TimeSpent.Hours, a.Date, a.Note))
                ?.ToList();

            return result ?? new List<ActivityDto>();
        }
    }
}