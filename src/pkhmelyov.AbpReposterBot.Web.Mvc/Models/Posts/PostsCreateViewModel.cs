using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Models.Posts
{
    [AutoMapTo(typeof(CreatePostInput))]
    public class PostsCreateViewModel
    {
        [Required]
        public string Body { get; set; }
    }
}