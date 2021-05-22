using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DjelatnikUserControl : System.Web.UI.UserControl
	{
		protected void Page_Load( object sender, EventArgs e )
		{

		}

		public void SetInfo( Djelatnik d )
		{
			lblDjelatnikName.Text = d.ToString();
			lblDjelatnikProjekti.Text = SetProjektiNames(d.IDDjelatnik);
			BtnDetalji.Attributes.Add("id", d.IDDjelatnik.ToString());
		}

		private string SetProjektiNames(int idDjelatnik)
		{
			IEnumerable<Projekt> projektiDjelatnika = Repozitorij.GetProjektiDjelatnika(idDjelatnik);
			StringBuilder sb = new StringBuilder();
			foreach ( Projekt projekt in projektiDjelatnika )
				sb.Append(projekt.ToString() + Environment.NewLine);

			return sb.ToString();
		}

		protected void OpenDjelatnikInfoPage( LinkButton b )
			=> Response.Redirect($"DetaljiDjelatnika.aspx?id={int.Parse(b.Attributes["id"])}");
		
		protected void BtnDetalji_Click( object sender, EventArgs e )
		{
			LinkButton b = sender as LinkButton;
			OpenDjelatnikInfoPage(b);
		}
	}
}