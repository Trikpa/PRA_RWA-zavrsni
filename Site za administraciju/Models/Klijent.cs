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

		public Klijent( int idKlijent, string naziv )
		{
			IDKlijent = idKlijent;
			Naziv = naziv;
		}

		public override string ToString() => Naziv;
	}
}