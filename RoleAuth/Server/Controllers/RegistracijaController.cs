using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleAuth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleAuth.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegistracijaController : ControllerBase
	{
		UserManager<IdentityUser> um;

		public RegistracijaController(UserManager<IdentityUser> u)
		{
			um = u;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Registracija reg)
		{
			var NoviKorisnik = new IdentityUser(){ UserName = reg.Mejl, Email = reg.Mejl };

			/* Ovo gore je kratka forma ovoga :) 
			NoviKorisnik.UserName = reg.Mejl;
			NoviKorisnik.Email = reg.Mejl;*/

			var rezultat = await um.CreateAsync(NoviKorisnik, reg.Sifra);
			return rezultat.Succeeded ? 
				Ok(new RegistracijaRezultat { Uspesno = true }) : 
				Ok(new RegistracijaRezultat { Uspesno = false });

		}

	}
}
