using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Models.Posts
{
    public class PostsSendViewModel
    {
        [Required]
        public int Id { get; set; }

        public PostListDto Post { get; set; }

        public PagedResultDto<ChannelDto> Channels { get; set; }
    }
}