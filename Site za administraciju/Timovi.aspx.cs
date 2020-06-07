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
	public partial class Timovi : System.Web.UI.Page
	{
		private Djelatnik djelatnik;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");

			djelatnik = Session["djelatnik"] as Djelatnik;

			if ( djelatnik.Tip != TipDjelatnika.Direktor )
				Response.Redirect("Login.aspx");

			LoadTeams();
		}

		private void LoadTeams()
		{
			phTeams.Controls.Clear();
			
			IEnumerable<Tim> timovi = Repozitorij.GetTimovi();
			foreach ( Tim t in timovi )
			{
				TimUserControl tuc = LoadControl("User_Controls/TimUserControl.ascx") as TimUserControl;
				
				tuc.ID = $"{t.IDTim}";
				tuc.SetInfo(t);

				phTeams.Controls.Add(tuc);
			}
		}

		protected void BtnDodaj_Click( object sender, EventArgs e ) => Response.Redirect("DodajTim.aspx");
	}
}