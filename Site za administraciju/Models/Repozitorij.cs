using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

namespace Site_za_administraciju.Models
{
	public static class Repozitorij
	{
		public static DataSet Ds { get; set; }
		private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

		public static Djelatnik LoginUser( string email, string password )
		{
			SqlParameter[] parameters = new SqlParameter[4];

			parameters[0] = new SqlParameter("@email", SqlDbType.NVarChar, 50)
			{
				Direction = ParameterDirection.Input,
				Value = email
			};

			parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar, 50)
			{
				Direction = ParameterDirection.Input,
				Value = password
			};

			parameters[2] = new SqlParameter("@djelatnikID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "ProvjeriKorisnickoImeIZaporku", parameters);

			int idDjelatnik = (int)parameters[2].Value;

			if ( idDjelatnik > 0 )
				return GetDjelatnik(idDjelatnik);

			return null;
		}

		public static Djelatnik GetDjelatnik( int idDjelatnik, Tim tim )
		{
			DataTable tblDjelatnik = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeODjelatniku", idDjelatnik).Tables[0];

			if ( tblDjelatnik.Rows.Count == 0 )
				return null;

			DataRow row = tblDjelatnik.Rows[0];
			return new Djelatnik
			(
				idDjelatnik: (int)row["IDDjelatnik"],
				ime: row["Ime"].ToString(),
				prezime: row["Prezime"].ToString(),
				tip: (int)row["TipID"],
				email: row["Email"].ToString(),
				lozinka: row["Lozinka"].ToString(),
				datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
				tim: tim ?? GetTim((int)row["TipID"])
			);
		}
		
		public static Djelatnik GetDjelatnik( int idDjelatnik )
		{
			DataTable tblDjelatnik = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeODjelatniku", idDjelatnik).Tables[0];

			if ( tblDjelatnik.Rows.Count == 0 )
				return null;

			DataRow row = tblDjelatnik.Rows[0];
			return new Djelatnik
			(
				idDjelatnik: (int)row["IDDjelatnik"],
				ime: row["Ime"].ToString(),
				prezime: row["Prezime"].ToString(),
				tip: (int)row["TipID"],
				email: row["Email"].ToString(),
				lozinka: row["Lozinka"].ToString(),
				datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
				tim: GetTim((int)row["TipID"])
			);
		}

		public static IEnumerable<Djelatnik> GetDjelatniciWithoutDirectors()
		{
			var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "DohvatiSveDjelatnikeOsimDirektora").Tables[0];

			foreach ( DataRow row in tblDjelatnici.Rows )
				yield return new Djelatnik
				(
					idDjelatnik: (int)row["IDDjelatnik"],
					ime: row["Ime"].ToString(),
					prezime: row["Prezime"].ToString(),
					tip: (int)row["TipID"],
					email: row["Email"].ToString(),
					datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
					tim: GetTim((int)row["TipID"])
				);
		}
		public static IEnumerable<Djelatnik> GetDjelatniciThatWorkOnProjekt( Projekt p )
		{
			var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "DohvatiDjelatnikeKojiRadeNaProjektu", p.IDProjekt).Tables[0];

			foreach ( DataRow row in tblDjelatnici.Rows )
				yield return new Djelatnik
				(
					idDjelatnik: (int)row["IDDjelatnik"],
					ime: row["Ime"].ToString(),
					prezime: row["Prezime"].ToString(),
					tip: (int)row["TipID"],
					email: row["Email"].ToString(),
					datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
					tim: GetTim((int)row["TipID"])
				);
		}

		public static Klijent GetKlijent( int idKlijent )
		{
			DataTable tblKlijent = SqlHelper.ExecuteDataset(cs, "DohvatiKlijenta", idKlijent).Tables[0];

			if ( tblKlijent.Rows.Count == 0 )
				return null;

			DataRow row = tblKlijent.Rows[0];
			return new Klijent
			(
				idKlijent: (int)row["IDKlijent"],
				naziv: row["Naziv"].ToString(),
				telefon: row["Telefon"].ToString(),
				email: row["Email"].ToString()
			);
		}

		public static IEnumerable<Projekt> GetProjektiDjelatnika( int userID )
		{
			var tblProjekti = SqlHelper.ExecuteDataset(cs, "DohvatiProjekteNaKojimaDjelatnikMozeRaditi", userID).Tables[0];

			foreach ( DataRow row in tblProjekti.Rows )
				yield return new Projekt
				(
					idProjekt: (int)row["IDProjekt"],
					naziv: row["Naziv"].ToString(),
					datumOtvaranja: DateTime.Parse(row["DatumOtvaranja"].ToString()),
					voditelj: GetDjelatnik( (int)row["VoditeljID"] ),
					klijent: GetKlijent( (int)row["IDKlijent"] ),
					opisProjekta:  row["OpisProjekta"].ToString()
				);
		}
		public static IEnumerable<Projekt> GetProjektiKlijenta( Klijent k )
		{
			var tblProjekti = SqlHelper.ExecuteDataset(cs, "DohvatiProjekteKlijenta", k.IDKlijent).Tables[0];

			foreach ( DataRow row in tblProjekti.Rows )
				yield return new Projekt
				(
					idProjekt: (int)row["IDProjekt"],
					naziv: row["Naziv"].ToString(),
					datumOtvaranja: DateTime.Parse(row["DatumOtvaranja"].ToString()),
					voditelj: GetDjelatnik((int)row["VoditeljID"]),
					klijent: k,
					opisProjekta: row["OpisProjekta"].ToString()
				);
		}
		public static IEnumerable<Klijent> GetKlijenti()
		{
			var tblKlijenti = SqlHelper.ExecuteDataset(cs, "DohvatiSveKlijente").Tables[0];

			foreach ( DataRow row in tblKlijenti.Rows )
				yield return new Klijent
				(
					idKlijent: (int)row["IDKlijent"],
					naziv: row["Naziv"].ToString(),
					telefon: row["Telefon"].ToString(),
					email: row["Email"].ToString()
				);
		}
		public static bool UpdateKlijent( Klijent k )
		{
			SqlParameter[] parameters = new SqlParameter[5];

			parameters[0] = new SqlParameter("@IDKlijent", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = k.IDKlijent
			};

			parameters[1] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = k.Naziv
			};

			parameters[2] = new SqlParameter("@Telefon", SqlDbType.NVarChar, 15)
			{
				Direction = ParameterDirection.Input,
				Value = k.Telefon
			};

			parameters[3] = new SqlParameter("@Email", SqlDbType.NVarChar, 25)
			{
				Direction = ParameterDirection.Input,
				Value = k.Email
			};

			parameters[4] = new SqlParameter("@output", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajKlijenta", parameters);

			int output = (int)parameters[4].Value;

			return output == 1;
		}
		public static void AddNewKlijent( Klijent k )
		{
			SqlParameter[] parameters = new SqlParameter[3];

			parameters[0] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = k.Naziv
			};

			parameters[1] = new SqlParameter("@Telefon", SqlDbType.NVarChar, 15)
			{
				Direction = ParameterDirection.Input,
				Value = k.Telefon
			};

			parameters[2] = new SqlParameter("@Email", SqlDbType.NVarChar, 25)
			{
				Direction = ParameterDirection.Input,
				Value = k.Email
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNovogKlijenta", parameters);
		}

		public static void AddNewProjekt(Projekt p)
		{
			SqlParameter[] parameters = new SqlParameter[5];

			parameters[0] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = p.Naziv
			};

			parameters[1] = new SqlParameter("@DatumOtvaranja", SqlDbType.Date)
			{
				Direction = ParameterDirection.Input,
				Value = $"{p.DatumOtvaranja.ToShortDateString()}"
			};

			parameters[2] = new SqlParameter("@VoditeljID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = p.Voditelj.IDDjelatnik
			};
			
			parameters[3] = new SqlParameter("@KlijentID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = p.Klijent.IDKlijent
			};
			
			parameters[4] = new SqlParameter("@OpisProjekta", SqlDbType.NVarChar, 250)
			{
				Direction = ParameterDirection.Input,
				Value = p.OpisProjekta
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNoviProjekt", parameters);
		}

		public static Projekt GetProjekt( int idProjekt )
		{
			DataTable tblProjekt = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeOProjektu", idProjekt).Tables[0];

			if ( tblProjekt.Rows.Count == 0 )
				return null;

			DataRow row = tblProjekt.Rows[0];
			return new Projekt
			(
				idProjekt: (int)row["IDProjekt"],
				naziv: row["Naziv"].ToString(),
				datumOtvaranja: DateTime.Parse(row["DatumOtvaranja"].ToString()),
				voditelj: GetDjelatnik((int)row["VoditeljID"]),
				klijent: GetKlijent((int)row["KlijentID"]),
				opisProjekta: row["OpisProjekta"].ToString()
			);
		}

		public static bool UpdateProjekt( Projekt p )
		{
			SqlParameter[] parameters = new SqlParameter[5];

			parameters[0] = new SqlParameter("@IDProjekt", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = p.IDProjekt
			};

			parameters[1] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = p.Naziv
			};

			parameters[2] = new SqlParameter("@DatumOtvaranja", SqlDbType.Date)
			{
				Direction = ParameterDirection.Input,
				Value = p.DatumOtvaranja
			};

			parameters[3] = new SqlParameter("@OpisProjekta", SqlDbType.NVarChar, 250)
			{
				Direction = ParameterDirection.Input,
				Value = p.OpisProjekta
			};
			
			parameters[4] = new SqlParameter("@output", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajProjekt", parameters);

			int output = (int)parameters[4].Value;

			return output == 1;
		}

		public static IEnumerable<Tim> GetTimovi()
		{
			var tblTimovi = SqlHelper.ExecuteDataset(cs, "DohvatiSveTimove").Tables[0];

			foreach ( DataRow row in tblTimovi.Rows )
				yield return new Tim
				(
					idTim: (int)row["IDTim"],
					naziv: row["Naziv"].ToString(),
					voditelj: GetDjelatnik( (int)row["VoditeljID"] )
				);
		}

		public static Tim GetTim( int timID )
		{
			DataTable tblTim = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeOTimu", timID).Tables[0];

			if ( tblTim.Rows.Count == 0 )
				return null;

			DataRow row = tblTim.Rows[0];
			Tim tim = new Tim
			{
				IDTim = (int)row["IDTim"],
				Naziv = row["Naziv"].ToString()
			};
			tim.Voditelj = GetDjelatnik((int)row["VoditeljID"], tim);

			return tim;
		}
		
		public static Tim GetTimDjelatnika( int djelatnikID )
		{
			DataTable tblTim = SqlHelper.ExecuteDataset(cs, "DohvatiPodatkeOTimuDjelatnika", djelatnikID).Tables[0];

			if ( tblTim.Rows.Count == 0 )
				return null;

			DataRow row = tblTim.Rows[0];
			Tim tim = new Tim
			{
				IDTim = (int)row["IDTim"],
				Naziv = row["Naziv"].ToString()
			};
			tim.Voditelj = GetDjelatnik((int)row["VoditeljID"], tim);

			return tim;
		}

		public static bool UpdateTim( Tim t )
		{
			SqlParameter[] parameters = new SqlParameter[3];

			parameters[0] = new SqlParameter("@IDTim", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = t.IDTim
			};

			parameters[1] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = t.Naziv
			};
			
			parameters[2] = new SqlParameter("@output", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajTim", parameters);

			int output = (int)parameters[2].Value;

			return output == 1;
		}

		public static IEnumerable<Djelatnik> GetDjelatniciThatDontHaveATeam()
		{
			var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "[DohvatiDjelatnikeKojiNePripadajuTimu]").Tables[0];

			foreach ( DataRow row in tblDjelatnici.Rows )
				yield return new Djelatnik
				(
					idDjelatnik: (int)row["IDDjelatnik"],
					ime: row["Ime"].ToString(),
					prezime: row["Prezime"].ToString(),
					tip: (int)row["TipID"],
					email: row["Email"].ToString(),
					datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
					tim: null
				);
		}

		public static void AddNewTim( Tim t )
		{
			SqlParameter[] parameters = new SqlParameter[2];

			parameters[0] = new SqlParameter("@Naziv", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = t.Naziv
			};

			parameters[1] = new SqlParameter("@VoditeljID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = t.Voditelj.IDDjelatnik
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNoviTim", parameters);
		}

		public static void AddNewDjelatnik( Djelatnik d )
		{
			SqlParameter[] parameters = new SqlParameter[8];

			parameters[0] = new SqlParameter("@Ime", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = d.Ime
			};
			
			parameters[1] = new SqlParameter("@Prezime", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = d.Prezime
			};

			parameters[2] = new SqlParameter("@TipID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = (int)d.Tip
			};

			parameters[3] = new SqlParameter("@Email", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = d.Email
			};
			
			parameters[4] = new SqlParameter("@Lozinka", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = d.Lozinka
			};
			
			parameters[5] = new SqlParameter("@DatumZaposlenja", SqlDbType.Date)
			{
				Direction = ParameterDirection.Input,
				Value = d.DatumZaposlenja.ToShortDateString()
			};
			
			parameters[6] = new SqlParameter("@TimID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = d.Tim == null ? (object)DBNull.Value : d.Tim.IDTim
			};
			
			parameters[7] = new SqlParameter("@output", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "DodajNovogDjelatnika", parameters);
		}

		public static bool UpdateDjelatnik( Djelatnik d )
		{
			SqlParameter[] parameters = new SqlParameter[7];

			//@ID int, @Ime nvarchar(30), @Prezime nvarchar(30), @TipID int, @Email nvarchar(50), @TimID int, @output bit output
			parameters[0] = new SqlParameter("@IDDjelatnik", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = d.IDDjelatnik
			};

			parameters[1] = new SqlParameter("@Ime", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = d.Ime
			};
			
			parameters[2] = new SqlParameter("@Prezime", SqlDbType.NVarChar, 30)
			{
				Direction = ParameterDirection.Input,
				Value = d.Prezime
			};

			parameters[3] = new SqlParameter("@TipID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = (int)d.Tip
			};
			
			parameters[4] = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
			{
				Direction = ParameterDirection.Input,
				Value = d.Email
			};

			parameters[5] = new SqlParameter("@TimID", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = d.Tim.IDTim
			};

			parameters[6] = new SqlParameter("@output", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajDjelatnika", parameters);

			int output = (int)parameters[6].Value;

			return output == 1;
		}

		public static bool ChangeDjelatnikPassword( Djelatnik d )
		{
			SqlParameter[] parameters = new SqlParameter[3];

			parameters[0] = new SqlParameter("@IDDjelatnik", SqlDbType.Int)
			{
				Direction = ParameterDirection.Input,
				Value = d.IDDjelatnik
			};

			parameters[1] = new SqlParameter("@NovaLozinka", SqlDbType.NVarChar, 50)
			{
				Direction = ParameterDirection.Input,
				Value = d.Lozinka
			};

			parameters[2] = new SqlParameter("@output", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};

			SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "AzurirajLozinku", parameters);

			int output = (int)parameters[2].Value;

			return output == 1;
		}
		public static IEnumerable<Djelatnik> GetDjelatniciTima( Tim t )
		{
			var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "DohvatiSveDjelatnikeIzTima", t.IDTim).Tables[0];

			foreach ( DataRow row in tblDjelatnici.Rows )
				yield return new Djelatnik
				(
					idDjelatnik: (int)row["IDDjelatnik"],
					ime: row["Ime"].ToString(),
					prezime: row["Prezime"].ToString(),
					tip: (int)row["TipID"],
					email: row["Email"].ToString(),
					datumZaposlenja: DateTime.Parse(row["DatumZaposlenja"].ToString()),
					tim: t
				);
		}
	}
}