using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos
{
    [AutoMap(typeof(ScheduleItem))]
    public class ScheduleItemDto : EntityDto
    {
        public virtual int PostId { get; set; }
        public virtual long ChannelId { get; set; }
        public virtual DateTime ScheduleDate { get; set; }
        public virtual bool Done { get; set; }
    }
}