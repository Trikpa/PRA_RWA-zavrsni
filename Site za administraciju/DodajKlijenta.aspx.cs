using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DodajKlijenta : System.Web.UI.Page
	{
		protected void Page_Load( object sender, EventArgs e )
		{

		}

		protected void BtnDodaj_Click( object sender, EventArgs e )
		{
			AddKlijentToDatabase();
			Response.Redirect("Klijenti.aspx");
		}

		private void AddKlijentToDatabase()
		{
			Klijent k = new Klijent
			(
				naziv: tbNaziv.Text,
				telefon: tbTelefon.Text,
				email: tbEmail.Text
			);

			Repozitorij.AddNewKlijent(k);
		}

		protected void BtnPovratak_Click( object sender, EventArgs e ) => Response.Redirect("Klijenti.aspx");
	}
}