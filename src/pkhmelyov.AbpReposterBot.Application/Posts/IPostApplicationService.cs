using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public interface IPostApplicationService : IApplicationService
    {
        Task<ListResultDto<PostListDto>> GetAll();
        Task<PostListDto> Create(CreatePostInput input);
        Task<PostListDto> GetById(int id);
    }
}