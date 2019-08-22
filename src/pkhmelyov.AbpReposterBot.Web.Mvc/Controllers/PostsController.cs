using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pkhmelyov.AbpReposterBot.Controllers;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Controllers
{
    public class PostsController : AbpReposterBotControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}