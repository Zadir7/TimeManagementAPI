using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharedData.DTO;
using WebServices.Abstracts;

namespace TimeManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityWebService _activityService;

        public ActivityController(IActivityWebService activityService)
        {
            _activityService = activityService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<ActivityDto> Get(Guid id)
        {
            return _activityService.Get(id);
        }
        
        [HttpGet]
        public ActionResult<List<ActivityDto>> GetList([FromBody] UserActivityListRequest request)
        {
            return _activityService.GetList(request);
        }

        [HttpPost]
        public ActionResult<Guid> PostAsync([FromBody] ActivityDto request)
        {
            return _activityService.Create(request);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] ActivityDto request)
        {
            return _activityService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        { 
            return _activityService.Delete(id);
        }
    }
}