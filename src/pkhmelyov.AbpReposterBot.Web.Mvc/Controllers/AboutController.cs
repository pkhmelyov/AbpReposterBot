using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using pkhmelyov.AbpReposterBot.Controllers;

namespace pkhmelyov.AbpReposterBot.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : AbpReposterBotControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
