using Abp.Application.Services.Dto;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Models.Common
{
    public class IndexViewModel<T>
    {
        public PagedResultDto<T> Page { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}