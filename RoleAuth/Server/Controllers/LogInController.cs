using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoleAuth.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoleAuth.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LogInController : ControllerBase
	{
		IConfiguration conf;
		SignInManager<IdentityUser> sim;

		public LogInController(IConfiguration c, SignInManager<IdentityUser> i)
		{
			conf = c;
			sim = i;
		}

		[HttpPost]
		public async Task<IActionResult> LogOn([FromBody]Login lo)
		{
			var rez = await sim.PasswordSignInAsync(lo.Mejl, lo.Sifra, false, false);

			if (!rez.Succeeded)
				return BadRequest(new LoginRezultat { Uspesno = false, Greska = "Jok bre!" });

			var klejm = new[]
			{
				new Claim(ClaimTypes.Name, lo.Mejl)
			};

			var kljuc = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["JwtSecurityKey"]));
			var kredencijali = new SigningCredentials(kljuc, SecurityAlgorithms.HmacSha256);
			var trajanje = DateTime.Now.AddDays(int.Parse(conf["JwtIsticeDana"]));

			var token = new JwtSecurityToken(
				conf["JwtIzdavac"],
				conf["JwtPublika"],
				klejm,
				expires: trajanje,
				signingCredentials: kredencijali
			);

			return Ok(new LoginRezultat { Uspesno = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
		}
	}
}
