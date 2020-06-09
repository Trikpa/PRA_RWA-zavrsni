using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class Djelatnici : System.Web.UI.Page
	{
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");

			ShowAllDjelatnici();
		}

		private void ShowAllDjelatnici()
		{
			IEnumerable<Djelatnik> djelatnici = Repozitorij.GetDjelatniciWithoutDirectors();
			foreach ( Djelatnik djelatnik in djelatnici )
			{
				DjelatnikUserControl puc = LoadControl("User_Controls/DjelatnikUserControl.ascx") as DjelatnikUserControl;
				puc.ID = $"{djelatnik.IDDjelatnik}";
				puc.SetInfo(djelatnik);

				phDjelatnici.Controls.Add(puc);
			}
		}

		protected void BtnDodaj_Click( object sender, EventArgs e ) => Response.Redirect("DodajDjelatnika.aspx");
	}
}