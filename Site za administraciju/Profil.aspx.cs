using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class Profil : System.Web.UI.Page
	{
		private Djelatnik d;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");
			else
			{
				d = Session["djelatnik"] as Djelatnik;
				if ( !IsPostBack )
					FillForm();
			}
		}

		private void FillForm()
		{
			d.Tim = Repozitorij.GetTimDjelatnika(d.IDDjelatnik);
			lblIme.Text = d.Ime;
			lblPrezime.Text = d.Prezime;
			lblTim.Text = d.Tim.ToString();
			tbEmail.Text = d.Email;
			lblTipDjelatnika.Text = d.Tip.ToString();
			lblDatumZaposlenja.Text = d.DatumZaposlenja.ToShortDateString();
		}

		protected void BtnSpremi_Click( object sender, EventArgs e ) => UpdateDjelatnik();

		private void UpdateDjelatnik()
		{
			d.Email = tbEmail.Text;

			Repozitorij.UpdateDjelatnik(d);

			ChangeTextBoxFieldsState(enabled: false);
		}

		protected void BtnPovratak_Click( object sender, EventArgs e ) => Response.Redirect("Djelatnici.aspx");
		protected void BtnUredi_Click( object sender, EventArgs e ) => ChangeTextBoxFieldsState(enabled: true);
		protected void BtnPromijeniSifru_Click( object sender, EventArgs e ) => Response.Redirect("PromijeniSifru.aspx");

		private void ChangeTextBoxFieldsState( bool enabled ) => tbEmail.Enabled = enabled;
	}
}