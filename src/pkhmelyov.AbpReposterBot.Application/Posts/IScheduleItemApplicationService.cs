using System;
using System.Collections.Generic;
using Abp.Application.Services;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public interface IScheduleItemApplicationService : IAsyncCrudAppService<ScheduleItemDto>
    {
        IEnumerable<ScheduleItemDto> GetItems(DateTime scheduleDate, int take);
    }
}