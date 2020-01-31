using Abp.Application.Services.Dto;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos 
{
    public class GetAllFilteredInput {
        public bool? Own { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}