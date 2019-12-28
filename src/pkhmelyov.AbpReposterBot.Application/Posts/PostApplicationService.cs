using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class PostApplicationService : AsyncCrudAppService<Post, PostListDto>, IPostApplicationService
    {
        public PostApplicationService(IRepository<Post> repository) : base(repository) { }
    }
}