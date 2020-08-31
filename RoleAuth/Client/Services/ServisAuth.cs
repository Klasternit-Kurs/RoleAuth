using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using RoleAuth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;


namespace RoleAuth.Client.Services
{
	public class ServisAuth : IServisAuth
	{
		HttpClient httpc;
		AuthenticationStateProvider asp;
		ILocalStorageService lokalniStor;

		public ServisAuth(System.Net.Http.HttpClient h, AuthenticationStateProvider a, ILocalStorageService l)
		{
			httpc = h;
			asp = a;
			lokalniStor = l;
		}

		public async Task<RegistracijaRezultat> Registracija(Registracija reg)
		{
			//Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Prerelease
			//TODO var rez = await httpc.PostJsonAsync<RegistracijaRezultat>("registracija", reg);
			return null;
		}

		public Task<LoginRezultat> Login(Login log)
		{
			throw new NotImplementedException();
		}

		public Task Logout()
		{
			throw new NotImplementedException();
		}

		
	}
}
