using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using Utilities;

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

			Ds = SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, "ProvjeriKorisnickoImeIZaporku", parameters);

			int idDjelatnik = (int)parameters[2].Value;

			if ( idDjelatnik > 0 )
				return GetDjelatnik(idDjelatnik);

			return null;
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
				tim: row["Tim"].ToString()
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
				naziv: row["Naziv"].ToString()
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

		public static IEnumerable<Klijent> GetKlijenti()
		{
			var tblKlijenti = SqlHelper.ExecuteDataset(cs, "DohvatiSveKlijente").Tables[0];

			foreach ( DataRow row in tblKlijenti.Rows )
				yield return new Klijent
				(
					idKlijent: (int)row["IDKlijent"],
					naziv: row["Naziv"].ToString()
				);
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
	}
}