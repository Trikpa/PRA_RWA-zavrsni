using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_za_administraciju.Models
{
	public class SatiNaProjektu
	{
		public Projekt Projekt { get; set; }
		public double RadniSati { get; set; }
		public double PrekovremeniSati { get; set; }
	}
}