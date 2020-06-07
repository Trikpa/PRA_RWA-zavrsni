using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju.User_Controls
{
	public partial class TimUserControl : System.Web.UI.UserControl
	{
		protected void Page_Load( object sender, EventArgs e )
		{

		}

		public void SetInfo( Tim t )
		{
			lblTeamName.Text = t.Naziv;
			BtnDetalji.Attributes.Add("id", t.IDTim.ToString());
		}

		protected void OpenTimInfoPage( LinkButton b )
			=> Response.Redirect($"DetaljiTima.aspx?id={int.Parse(b.Attributes["id"])}");

		protected void BtnDetalji_Click( object sender, EventArgs e )
		{
			LinkButton b = sender as LinkButton;
			OpenTimInfoPage(b);
		}
	}
}