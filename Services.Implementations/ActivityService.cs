using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Repositories.Abstracts;
using Services.Abstracts;
using SharedData.DTO;
using SharedData.Locale;
using SharedData.Models;
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


        public ServiceResult Add(ActivityDto activityModel)
        {
            //TODO: Reimplement model validation
            var user = _userRepository.GetById(activityModel.User.Id);
            if (user is null)
            {
                return new FailedResult(ServiceErrors.UserDoesNotExist);
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
                return new FailedResult(ServiceErrors.DatabaseIsNotResponding);
            }

            return new SuccessfulResult();
        }

        public ServiceResult Update(Guid id, ActivityDto activityModel)
        {
            if (_repository.GetById(id) is null)
            {
                return new FailedResult(ServiceErrors.ActivityDoesNotExist);
            }

            //TODO: Reimplement model validation
            
            var user = _userRepository.GetById(activityModel.User.Id);
            if (user is null)
            {
                return new FailedResult(ServiceErrors.UserDoesNotExist);
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
                return new FailedResult(ServiceErrors.DatabaseIsNotResponding);
            }

            return new SuccessfulResult();
        }

        public ServiceResult<ActivityDto> Get(Guid id)
        {
            var activity = _repository.GetById(id);
            if (activity is null) return new FailedResult<ActivityDto>(ServiceErrors.ActivityDoesNotExist);

            var activityDto = activity.Map(a => new ActivityDto(
                a.User.Map(u => new  SharedData.DTO.User(u.Id, $"{u.FirstName} + {u.LastName}")),
                a.TimeSpent.Hours,
                a.Date,
                a.Note)
            );
            
            return new SuccessfulResult<ActivityDto>(activityDto);
        }

        public ServiceResult Delete(Guid id)
        {
            var activity = _repository.GetById(id);
            if (activity is null) return new FailedResult(ServiceErrors.ActivityDoesNotExist);

            try
            {
                _repository.Delete(activity);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                //log exception
                return new FailedResult(ServiceErrors.DatabaseIsNotResponding);
            }

            return new SuccessfulResult();
        }

        public ServiceResult<List<ActivityDto>> GetList(UserActivityListRequest request)
        {
            var (userVm, month) = request;
            var result = _repository
                .GetActivitiesOfUserOnChosenMonth(userVm.Id, month)
                ?.ToList()
                ?.Map(a => new ActivityDto(userVm, a.TimeSpent.Hours, a.Date, a.Note))
                ?.ToList();

            return new SuccessfulResult<List<ActivityDto>>(result ?? new List<ActivityDto>());
        }
    }
}