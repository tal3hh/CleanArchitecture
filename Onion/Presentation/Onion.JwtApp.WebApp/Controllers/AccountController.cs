using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Onion.JwtApp.Application.Dtos.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using NuGet.Protocol;

namespace Onion.JwtApp.WebApp.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public IActionResult Register()
        {
            return View(new UserCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("http://localhost:44823/api/Account/Register",content);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ugurlu qeydiyyat";
                return View();
            }
            else
            {
				TempData["Danger"] = "Ugursuz qeydiyyat";
				return View();
			}

        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
			if (!ModelState.IsValid) return View(dto);

			var client = _httpClientFactory.CreateClient();
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:44823/api/Account/Login", content);

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var tokenmodel = System.Text.Json.JsonSerializer.Deserialize<JwtTokenResponseDto>(jsonData, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				if (tokenmodel?.Token != null)
				{
					var handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenmodel.Token);

					var claims = token.Claims.ToList();
					if (tokenmodel.Token != null)
						claims.Add(new Claim("RestorantToken", tokenmodel.Token));

					var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

					var authProps = new AuthenticationProperties
					{
						ExpiresUtc = tokenmodel.ExpireDate,
						IsPersistent = true,
					};
					await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Service Error");
			}
			else
			{
				ModelState.AddModelError("", "Username and password is wrong");
			}

			return View();
		}
	}
}
