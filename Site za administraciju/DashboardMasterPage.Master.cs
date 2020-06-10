using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DashboardMasterPage : System.Web.UI.MasterPage
	{
		public HyperLink navItemProjekti { get; set; }
		public HyperLink navItemMojTim { get; set; }
		public HyperLink navItemIzvjestaji { get; set; }
		public HyperLink navItemTimovi { get; set; }
		public HyperLink navItemDjelatnici { get; set; }
		public HyperLink navItemKlijenti { get; set; }

		protected void Page_Load( object sender, EventArgs e )
		{
			Djelatnik djelatnik = Session["djelatnik"] as Djelatnik;
			if ( djelatnik == null )
				Response.Redirect("Login.aspx");

			EditMenu(djelatnik.Tip);
			lblFirstLastName.InnerText = djelatnik.ToString();

			SetReferencesForNavItems();
		}

		private void SetReferencesForNavItems()
		{
			navItemProjekti = navitemProjekti;
			navItemMojTim = navitemMojTim;
			navItemIzvjestaji = navitemIzvjestaji;
			navItemTimovi = navitemTimovi;
			navItemDjelatnici = navitemDjelatnici;
			navItemKlijenti = navitemKlijenti;
		}

		private void EditMenu( TipDjelatnika tip )
		{
			if ( tip == TipDjelatnika.Direktor )
				navitemMojTim.Visible = false;
			if ( tip == TipDjelatnika.VoditeljTima )
				HideExcessItems();
		}

		private void HideExcessItems()
		{
			navitemTimovi.Visible = false;
			navitemKlijenti.Visible = false;
			navitemDjelatnici.Visible = false;
		}

		protected void BtnLogout_Click( object sender, EventArgs e )
		{
			Response.Cookies.Clear();
			Session.Clear();
			ViewState.Clear();
			Response.Redirect("Login.aspx");
		}

		protected void BtnProfil_Click( object sender, EventArgs e ) => Response.Redirect("Profil.aspx");
	}
}