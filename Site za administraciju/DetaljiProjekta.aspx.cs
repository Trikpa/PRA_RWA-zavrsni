using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DetaljiProjekta : System.Web.UI.Page
	{
		private Projekt p;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Request.QueryString["id"] == null || Session["djelatnik"] == null )
				Response.Redirect("Projekti.aspx");
			else
			{
				int idProjekt = int.Parse(Request.QueryString["id"].ToString());
				p = Repozitorij.GetProjekt(idProjekt);
				if (!IsPostBack)
					FillForm();
			}
		}

		private void FillForm()
		{
			tbNaziv.Text = p.Naziv;
			tbDatum.Text = p.DatumOtvaranja.ToShortDateString();
			tbVoditelj.Text = p.Voditelj.ToString();
			tbKlijent.Text = p.Klijent.ToString();
			tbOpis.Text = p.OpisProjekta;
		}

		protected void BtnSpremi_Click( object sender, EventArgs e ) => UpdateProjekt();

		private void UpdateProjekt()
		{
			p.Naziv = tbNaziv.Text;
			p.DatumOtvaranja = DateTime.Parse(tbDatum.Text);
			p.OpisProjekta = tbOpis.Text;

			Repozitorij.UpdateProjekt(p);

			ChangeTextBoxFieldsState(enabled: false);
		}

		protected void BtnPovratak_Click( object sender, EventArgs e ) => Response.Redirect("Projekti.aspx");
		protected void BtnUredi_Click( object sender, EventArgs e ) => ChangeTextBoxFieldsState(enabled: true);

		private void ChangeTextBoxFieldsState( bool enabled )
		{
			tbNaziv.Enabled = enabled;
			tbDatum.Enabled = enabled;
			tbOpis.Enabled = enabled;
		}
	}
}