using Microsoft.AspNetCore.Antiforgery;
using pkhmelyov.AbpReposterBot.Controllers;

namespace pkhmelyov.AbpReposterBot.Web.Host.Controllers
{
    public class AntiForgeryController : AbpReposterBotControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
