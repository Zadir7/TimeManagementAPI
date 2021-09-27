using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharedData.DTO;

namespace WebServices.Abstracts
{
    public interface IActivityWebService
    {
        public ActionResult<ActivityDto> Get(Guid id);
        public ActionResult<List<ActivityDto>> GetList(UserActivityListRequest request);
        public ActionResult<Guid> Create(ActivityDto request);
        public ActionResult Update(Guid id, ActivityDto request);
        public ActionResult Delete(Guid id);
    }
}