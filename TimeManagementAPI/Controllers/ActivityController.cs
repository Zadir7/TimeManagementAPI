using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;
using SharedData.DTO;
using SharedData.Requests;

namespace TimeManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetAsync(Guid id)
        {
            return await _activityService.Get(id);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ActivityDto>>> GetUsersActivityListAsync([FromBody] UserActivityListRequest request)
        {
            var (user, month) = request;
            return await _activityService.GetUserActivitiesOnSelectedMonth(user, month);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ActivityDto request)
        {
            return await _activityService.Add(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] ActivityDto request)
        {
            return await _activityService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        { 
            return await _activityService.Delete(id);
        }
    }
}