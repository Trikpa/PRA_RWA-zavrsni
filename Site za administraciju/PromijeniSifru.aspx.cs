using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class PromijeniSifru : System.Web.UI.Page
	{
		private Djelatnik d;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");

			d = Session["djelatnik"] as Djelatnik;
		}

		protected void BtnAzurirajSifru_Click( object sender, EventArgs e )
		{
			d.Lozinka = tbNovaLozinka.Text;
			Repozitorij.ChangeDjelatnikPassword(d);
			Response.Redirect("Profil.aspx");
		}

		protected void BtnOdustani_Click( object sender, EventArgs e ) => Response.Redirect("Profil.aspx");

		protected void CvTrenutnaLozinka_ServerValidate( object source, ServerValidateEventArgs args )
		{
			if ( d.Lozinka != tbTrenutnaLozinka.Text )
				args.IsValid = false;
			else
				args.IsValid = false;
		}
	}
}