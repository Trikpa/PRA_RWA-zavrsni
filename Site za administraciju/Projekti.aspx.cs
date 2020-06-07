using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class Projekti : System.Web.UI.Page
	{
		private Djelatnik djelatnik;
		protected void Page_Load( object sender, EventArgs e )
		{
			djelatnik = Session["djelatnik"] as Djelatnik;
			if ( djelatnik == null )
				Response.Redirect("Login.aspx");

			LoadUserProjects();
		}

		private void LoadUserProjects()
		{
			phProjects.Controls.Clear();

			int userID = djelatnik.IDDjelatnik;
			IEnumerable<Projekt> projekti = Repozitorij.GetProjektiDjelatnika(userID);
			foreach ( Projekt p in projekti )
			{
				ProjektUserControl puc = LoadControl("User_Controls/ProjektUserControl.ascx") as ProjektUserControl;
				puc.ID = $"{p.IDProjekt}";
				puc.SetInfo(p);

				phProjects.Controls.Add(puc);
			}
		}

		protected void BtnDodaj_Click( object sender, EventArgs e ) => Response.Redirect("DodajProjekt.aspx");
	}
}