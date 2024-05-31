using BpkbMvc.Models;
using BpkbMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;

namespace BpkbMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var token = await _authService.Login(loginModel, HttpContext.RequestAborted);
            if (token == null)
            {
                if (HttpContext.Response.StatusCode == 401)
                {
                    ViewBag.ErrorMessage = "Unauthorized. Please check your username and password.";
                }
                else
                {
                    ViewBag.ErrorMessage = "Login failed. Username or password incorrect.";
                }
                return View(loginModel);
            }

            var jsonObject = JsonSerializer.Deserialize<JsonElement>(token);
            var tokenParsed = jsonObject.GetProperty("token").GetString();
            HttpContext.Session.SetString("Token", tokenParsed);


            return RedirectToAction("Index", "TrBpkb");
        }
    }
}
