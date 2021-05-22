using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site_za_administraciju.Models;

namespace Site_za_evidenciju_radnih_sati.Models
{
	public class Satnica
	{
		public int IDSatnica { get; set; }
		public Djelatnik Djelatnik { get; set; }
		public DateTime DatumSatnice { get; set; }
		public DateTime DatumPredaje { get; set; }
		public int ProjektID { get; set; }
		public double RadniSati { get; set; }
		public double PrekovremeniSati { get; set; }
		public string Komentar { get; set; }
		public int ZaPotvrditi { get; set; }
		public int JePotvrdjeno { get; set; }
	}
}