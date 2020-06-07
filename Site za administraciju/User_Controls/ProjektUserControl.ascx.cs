using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class ProjektUserControl : System.Web.UI.UserControl
	{
		protected void Page_Load( object sender, EventArgs e )
		{

		}

		public void SetInfo( Projekt p )
		{
			lblProjectTitle.Text = p.Naziv;
			lblProjectDescription.Text = p.OpisProjekta;
			BtnDetalji.Attributes.Add("id", p.IDProjekt.ToString());
		}

		protected void OpenProjektInfoPage( LinkButton b )
			=> Response.Redirect($"DetaljiProjekta.aspx?id={int.Parse(b.Attributes["id"])}");
		
		protected void BtnDetalji_Click( object sender, EventArgs e )
		{
			LinkButton b = sender as LinkButton;
			OpenProjektInfoPage(b);
		}
	}
}