using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class MojTim : System.Web.UI.Page
	{
		private Djelatnik d;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");

			d = Session["djelatnik"] as Djelatnik;
			ShowAllDjelatnici();
		}

		private void ShowAllDjelatnici()
		{
			IEnumerable<Djelatnik> djelatniciTima = Repozitorij.GetDjelatniciTima(d.Tim);
			foreach ( Djelatnik djelatnik in djelatniciTima )
			{
				DjelatnikUserControl puc = LoadControl("User_Controls/DjelatnikUserControl.ascx") as DjelatnikUserControl;
				puc.ID = $"{djelatnik.IDDjelatnik}";
				puc.SetInfo(djelatnik);

				phMojTim.Controls.Add(puc);
			}
		}
	}
}