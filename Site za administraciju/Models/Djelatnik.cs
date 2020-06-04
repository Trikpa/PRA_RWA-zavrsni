using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_za_administraciju.Models
{
	public enum TipDjelatnika
	{
		StalniDjelatnik = 1,
		HonorarniDjelatnik,
		Student,
		VoditeljTima,
		Direktor,
		Neaktivan
	}
	public class Djelatnik
	{
		public int IDDjelatnik { get; private set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public TipDjelatnika Tip { get; set; }
		public string Email { get; set; }
		public string Lozinka { get; set; }
		public DateTime DatumZaposlenja { get; set; }
		public string Tim { get; set; }

		public Djelatnik( int idDjelatnik, string ime, string prezime, int tip, string email, string lozinka, DateTime datumZaposlenja, string tim )
		{
			IDDjelatnik = idDjelatnik;
			Ime = ime;
			Prezime = prezime;
			Tip = (TipDjelatnika)tip;
			Email = email;
			Lozinka = lozinka;
			DatumZaposlenja = datumZaposlenja;
			Tim = tim;
		}

		public override string ToString() => $"{Ime} {Prezime}";
	}
}