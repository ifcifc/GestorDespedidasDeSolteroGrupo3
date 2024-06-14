using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task Login() 
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, 
                new AuthenticationProperties
                { 
                    RedirectUri = Url.Action("GoogleResponse")
                });
        }
        public async Task<IActionResult> GoogleResponse() {
            /*var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var accesToken = result.Properties.GetTokenValue("acess_token");
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(x => new
            { 
                x.Issuer,
                x.OriginalIssuer,
                x.Type,
                x.Value
            });
            */

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
