using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Models.Posts
{
    public class PostsSendViewModel
    {
        [Required]
        public long Id { get; set; }

        public PostListDto Post { get; set; }

        public PagedResultDto<ChannelDto> Channels { get; set; }

        public long ChannelId { get; set; }

        public IEnumerable<SelectListItem> ChannelItems
        {
            get => Channels.Items.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title,
                Selected = x.Id == ChannelId
            });
        }
    }
}