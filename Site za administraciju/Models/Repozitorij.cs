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

			if ( tblDjelatnik.Rows.Count == 0 ) return null;

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
	}
}