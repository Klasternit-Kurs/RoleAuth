using RoleAuth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleAuth.Client.Services
{
	public interface IServisAuth
	{
		Task Logout();

		Task<RegistracijaRezultat> Registracija(Registracija reg);
		Task<LoginRezultat> Login(Login log);

	}

}
