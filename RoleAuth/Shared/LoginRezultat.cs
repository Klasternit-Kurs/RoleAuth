using System;
using System.Collections.Generic;
using System.Text;

namespace RoleAuth.Shared
{
	public class LoginRezultat
	{
		public bool Uspesno { get; set; }
		public string Greska { get; set; }
		public string Token { get; set; }
	}
}
