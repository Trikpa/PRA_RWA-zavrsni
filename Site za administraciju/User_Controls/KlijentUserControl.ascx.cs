using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju.User_Controls
{
	public partial class KlijentUserControl : System.Web.UI.UserControl
	{
		protected void Page_Load( object sender, EventArgs e )
		{

		}
		public void SetInfo( Klijent k )
		{
			lblKlijentName.Text = k.Naziv;
			BtnDetalji.Attributes.Add("id", k.IDKlijent.ToString());
		}

		protected void OpenKlijentInfoPage( LinkButton b )
			=> Response.Redirect($"DetaljiKlijenta.aspx?id={int.Parse(b.Attributes["id"])}");

		protected void BtnDetalji_Click( object sender, EventArgs e )
		{
			LinkButton b = sender as LinkButton;
			OpenKlijentInfoPage(b);
		}
	}
}