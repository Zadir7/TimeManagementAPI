using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedData.DTO;
using SharedData.ViewModels;

namespace Services.Abstracts
{
    public interface IActivityService
    {
        public Task<ActionResult> Add(ActivityDto userModel);
        public Task<ActionResult> Update(Guid id, ActivityDto userModel);
        public Task<ActionResult<ActivityDto>> Get(Guid id);
        public Task<ActionResult> Delete(Guid id);
        public Task<List<ActivityDto>> GetUserActivitiesOnSelectedMonth(UserVm user, int month);
    }
}