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
		public Tim Tim { get; set; } = null;

		public Djelatnik( string ime, string prezime, int tip, string email, DateTime datumZaposlenja, Tim tim )
		{
			Ime = ime;
			Prezime = prezime;
			Tip = (TipDjelatnika)tip;
			Email = email;
			DatumZaposlenja = datumZaposlenja;
			Tim = tim;
		}

		public Djelatnik( string ime, string prezime, int tip, string email, string lozinka, DateTime datumZaposlenja, Tim tim )
			: this(ime, prezime, tip, email, datumZaposlenja, tim)
				=> Lozinka = lozinka;

		public Djelatnik( int idDjelatnik, string ime, string prezime, int tip, string email, DateTime datumZaposlenja, Tim tim )
			: this(ime, prezime, tip, email, datumZaposlenja, tim)
				=> IDDjelatnik = idDjelatnik;

		public Djelatnik( int idDjelatnik, string ime, string prezime, int tip, string email, string lozinka, DateTime datumZaposlenja, Tim tim )
			: this(idDjelatnik, ime, prezime, tip, email, datumZaposlenja, tim)
				=> Lozinka = lozinka;

		public override string ToString() => $"{Ime} {Prezime}";
		public override bool Equals( object obj ) => IDDjelatnik.Equals(( obj as Djelatnik ).IDDjelatnik);
		public override int GetHashCode() => IDDjelatnik.GetHashCode();
	}
}