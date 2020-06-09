using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DetaljiTima : System.Web.UI.Page
	{
		private Tim t;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Request.QueryString["id"] == null || Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");
			else
			{
				int timID = int.Parse(Request.QueryString["id"]);
				t = Repozitorij.GetTim(timID);

				if ( !IsPostBack )
					FillForm();
			}
		}

		private void FillForm()
		{
			tbNaziv.Text = t.Naziv;
			tbVoditelj.Text = t.Voditelj.ToString();
		}

		protected void BtnSpremi_Click( object sender, EventArgs e ) => UpdateProjekt();

		private void UpdateProjekt()
		{
			t.Naziv = tbNaziv.Text;

			Repozitorij.UpdateTim(t);

			ChangeTextBoxFieldsState(enabled: false);
		}

		protected void BtnPovratak_Click( object sender, EventArgs e ) => Response.Redirect("Timovi.aspx");
		protected void BtnUredi_Click( object sender, EventArgs e ) => ChangeTextBoxFieldsState(enabled: true);

		private void ChangeTextBoxFieldsState( bool enabled ) => tbNaziv.Enabled = enabled;
	}
}