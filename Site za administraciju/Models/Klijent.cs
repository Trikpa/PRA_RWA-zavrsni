using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_za_administraciju.Models
{
	public class Klijent
	{
		public int IDKlijent { get; set; }
		public string Naziv { get; set; }
		public string Telefon { get; set; }
		public string Email { get; set; }

		public Klijent( string naziv, string telefon, string email )
		{
			Naziv = naziv;
			Telefon = telefon;
			Email = email;
		}

		public Klijent( int idKlijent, string naziv, string telefon, string email )
			: this(naziv, telefon, email)
				=> IDKlijent = idKlijent;

		public override string ToString() => Naziv;
	}
}