using System;
using Abp.Domain.Entities;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class ScheduleItem : Entity
    {
        public virtual int PostId { get; set; }
        public virtual long ChannelId { get; set; }
        public virtual DateTime ScheduleDate { get; set; }
        public virtual bool Done { get; set; }
    }
}