using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DetaljiDjelatnika : System.Web.UI.Page
	{
		private Djelatnik d;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Request.QueryString["id"] == null || Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");
			else
			{
				int djelatnikID = int.Parse(Request.QueryString["id"]);
				d = Repozitorij.GetDjelatnik(djelatnikID);
				if ( !IsPostBack )
					FillForm();
				LoadProjektiDjelatnika();
			}
		}

		private void FillForm()
		{
			tbIme.Text = d.Ime;
			tbPrezime.Text = d.Prezime;

			LoadDdlTipDjelatnika();
			ddlTip.SelectedValue = d.Tip.ToString();

			tbEmail.Text = d.Email;
			tbDatumZaposlenja.Text = d.DatumZaposlenja.ToShortDateString();

			LoadDdlTimovi();
			ddlTim.SelectedValue = d.Tim.IDTim.ToString();
		}

		private void LoadProjektiDjelatnika()
		{
			IEnumerable<Projekt> projektiDjelatnika = Repozitorij.GetProjektiDjelatnika(d.IDDjelatnik);
			foreach ( Projekt projekt in projektiDjelatnika )
			{
				ProjektUserControl puc = LoadControl("User_Controls/ProjektUserControl.ascx") as ProjektUserControl;
				puc.ID = $"{projekt.IDProjekt}";
				puc.SetInfo(projekt);
				phProjektiDjelatnika.Controls.Add(puc);
			}
		}

		private void LoadDdlTimovi()
		{
			IEnumerable<Tim> timovi = Repozitorij.GetTimovi();
			ddlTim.Items.Clear();

			ddlTim.Items.Add(new ListItem
			{
				Text = "Nema tima",
				Value = $"{0}"
			});

			foreach ( Tim t in timovi )
				ddlTim.Items.Add(new ListItem
				{
					Text = t.Naziv,
					Value = t.IDTim.ToString()
				});
		}

		private void LoadDdlTipDjelatnika()
		{
			ddlTip.Items.Clear();

			foreach ( TipDjelatnika iTip in Enum.GetValues(typeof(TipDjelatnika)) )
				ddlTip.Items.Add(new ListItem
				{
					Text = iTip.ToString(),
					Value = $"{(int)iTip}"
				});
		}

		protected void BtnSpremi_Click( object sender, EventArgs e ) => UpdateDjelatnik();

		private void UpdateDjelatnik()
		{
			d.Ime = tbIme.Text;
			d.Prezime = tbPrezime.Text;
			d.Tip = (TipDjelatnika) int.Parse(ddlTip.SelectedValue);
			d.Email = tbEmail.Text;
			d.Tim = Repozitorij.GetTim(int.Parse(ddlTim.SelectedValue));

			Repozitorij.UpdateDjelatnik(d);

			ChangeTextBoxFieldsState(enabled: false);
		}

		protected void BtnPovratak_Click( object sender, EventArgs e ) => Response.Redirect("Djelatnici.aspx");
		protected void BtnUredi_Click( object sender, EventArgs e ) => ChangeTextBoxFieldsState(enabled: true);

		private void ChangeTextBoxFieldsState( bool enabled )
		{
			tbIme.Enabled = enabled;
			tbPrezime.Enabled = enabled;
			tbEmail.Enabled = enabled;
			ddlTip.Enabled = enabled;
			ddlTim.Enabled = enabled;
		}
	}
}