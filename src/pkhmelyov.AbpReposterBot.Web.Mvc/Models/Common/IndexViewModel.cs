using Abp.Application.Services.Dto;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Models.Common
{
    public class IndexViewModel<TFilter, TItem>
    {
        public TFilter FilterModel { get; set; }
        public PagedResultDto<TItem> Page { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}