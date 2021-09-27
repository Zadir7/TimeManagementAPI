using System;
using System.Collections.Generic;
using SharedData.DTO;
using SharedData.Models;

namespace Services.Abstracts
{
    public interface IActivityService
    {
        public ServiceResult Add(ActivityDto userModel);
        public ServiceResult Update(Guid id, ActivityDto userModel);
        public ServiceResult<ActivityDto> Get(Guid id);
        public ServiceResult Delete(Guid id);
        public ServiceResult<List<ActivityDto>> GetList(UserActivityListRequest request);
    }
}