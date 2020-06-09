using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DodajDjelatnika : System.Web.UI.Page
	{
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( !IsPostBack )
				LoadDropdowns();
		}

		private void LoadDropdowns()
		{
			LoadTimoviDropdown();
			LoadTipoviDropdown();
		}

		private void LoadTimoviDropdown()
		{
			IEnumerable<Tim> timovi = Repozitorij.GetTimovi();
			ddlTimovi.Items.Clear();

			ddlTimovi.Items.Add(new ListItem
			{
				Text = "--- odaberi ---",
				Selected = true,
				Value = $"{-1}"
			});
			
			ddlTimovi.Items.Add(new ListItem
			{
				Text = "Nema tima",
				Value = $"{0}"
			});

			foreach ( Tim t in timovi )
				ddlTimovi.Items.Add(new ListItem
				{
					Text = t.Naziv,
					Value = t.IDTim.ToString()
				});
		}
		
		private void LoadTipoviDropdown()
		{
			ddlTip.Items.Clear();

			ddlTip.Items.Add(new ListItem
			{
				Text = "--- odaberi ---",
				Selected = true,
				Value = $"{-1}"
			});

			foreach ( TipDjelatnika iTip in Enum.GetValues(typeof(TipDjelatnika)) )
				ddlTip.Items.Add( new ListItem
				{
					Text = iTip.ToString(),
					Value = $"{(int)iTip}"
				});
		}

		protected void BtnDodaj_Click( object sender, EventArgs e )
		{
			AddDjelatnikToDatabase();
			Response.Redirect("Djelatnici.aspx");
		}

		private void AddDjelatnikToDatabase()
		{
			Djelatnik d = new Djelatnik
		    (
				ime: tbIme.Text,
				prezime: tbPrezime.Text,
				tip: int.Parse(ddlTip.SelectedValue),
				email: tbEmail.Text,
				lozinka: tbLozinka.Text,
				datumZaposlenja: DateTime.Now,
				tim: int.Parse(ddlTimovi.SelectedValue) == 0 ? null : Repozitorij.GetTim(int.Parse(ddlTimovi.SelectedValue))
			);

			Repozitorij.AddNewDjelatnik(d);
		}
	}
}