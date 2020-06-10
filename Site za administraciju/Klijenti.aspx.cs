using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;
using Site_za_administraciju.User_Controls;

namespace Site_za_administraciju
{
	public partial class Klijenti : System.Web.UI.Page
	{
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");

			ShowAllKlijenti();
		}

		private void ShowAllKlijenti()
		{
			IEnumerable<Klijent> klijenti = Repozitorij.GetKlijenti();
			foreach ( Klijent klijent in klijenti )
			{
				KlijentUserControl puc = LoadControl("User_Controls/KlijentUserControl.ascx") as KlijentUserControl;
				puc.ID = $"{klijent.IDKlijent}";
				puc.SetInfo(klijent);

				phKlijenti.Controls.Add(puc);
			}
		}

		protected void BtnDodaj_Click( object sender, EventArgs e ) => Response.Redirect("DodajKlijenta.aspx");
	}
}