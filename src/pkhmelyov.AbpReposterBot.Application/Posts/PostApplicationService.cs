using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class PostApplicationService : AbpReposterBotAppServiceBase, IPostApplicationService
    {
        private readonly IRepository<Post> _postRepository;

        public PostApplicationService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ListResultDto<PostListDto>> GetAll()
        {
            var list = await _postRepository.GetAll().OrderByDescending(x => x.Id).ToListAsync();
            return new ListResultDto<PostListDto>(ObjectMapper.Map<List<PostListDto>>(list));
        }

        public async Task<Post> Create(CreatePostInput input)
        {
            var post = ObjectMapper.Map<Post>(input);
            return await _postRepository.InsertAsync(post);
        }
    }
}