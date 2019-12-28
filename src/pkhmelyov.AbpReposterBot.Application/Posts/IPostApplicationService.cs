using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public interface IPostApplicationService : IAsyncCrudAppService<PostListDto> { }
}