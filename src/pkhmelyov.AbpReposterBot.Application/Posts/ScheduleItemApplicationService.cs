using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Application.Posts
{
    public class ScheduleItemApplicationService : AsyncCrudAppService<ScheduleItem, ScheduleItemDto>, IScheduleItemApplicationService
    {
        public ScheduleItemApplicationService(IRepository<ScheduleItem, int> repository) : base(repository) { }

        public IEnumerable<ScheduleItemDto> GetItems(DateTime scheduleDate, int take)
        {
            return Repository.GetAll().Where(x => !x.Done && x.ScheduleDate <= scheduleDate).Take(take).Select(x => ObjectMapper.Map<ScheduleItemDto>(x));
        }
    }
}