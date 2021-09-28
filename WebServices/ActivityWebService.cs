using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;
using SharedData.DTO;
using WebServices.Abstracts;

namespace WebServices
{
    public class ActivityWebService : IActivityWebService
    {
        private readonly IActivityService _activityService;

        public ActivityWebService(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public ActionResult<ActivityDto> Get(Guid id) => _activityService.Get(id).AsActionResult();

        public ActionResult<List<ActivityDto>> GetList(UserActivityListRequest request) => _activityService.GetList(request).AsActionResult();

        public ActionResult<Guid> Create(ActivityDto request) => _activityService.Add(request).AsActionResult();

        public ActionResult Update(Guid id, ActivityDto request) => _activityService.Update(id, request).AsActionResult();

        public ActionResult Delete(Guid id) => _activityService.Delete(id).AsActionResult();
    }
}