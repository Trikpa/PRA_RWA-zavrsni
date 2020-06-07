using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_za_administraciju.Models
{
	public class Tim
	{
		public int IDTim { get; set; }
		public string Naziv { get; set; }
		public Djelatnik Voditelj { get; set; }

		public Tim( int idTim, string naziv, Djelatnik voditelj )
		{
			IDTim = idTim;
			Naziv = naziv;
			Voditelj = voditelj;
		}

		public override string ToString() => Naziv;
	}
}