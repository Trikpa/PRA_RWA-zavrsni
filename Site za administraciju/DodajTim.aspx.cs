using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DodajTim : System.Web.UI.Page
	{
		protected void Page_Load( object sender, EventArgs e )
		{
			if (!IsPostBack)
				LoadDjelatniciThatDontHaveATeam();

		}

		protected void BtnDodaj_Click( object sender, EventArgs e ) => AddTim();

		private void LoadDjelatniciThatDontHaveATeam()
		{
			IEnumerable<Djelatnik> djelatnici = Repozitorij.GetDjelatniciThatDontHaveATeam();

			ddlVoditeljProjekta.Items.Clear();

			ddlVoditeljProjekta.Items.Add(new ListItem
			{
				Text = "--- odaberi ---",
				Selected = true,
				Value = $"{-1}"
			});

			foreach ( Djelatnik d in djelatnici )
			{
				ddlVoditeljProjekta.Items.Add(new ListItem
				{
					Text = d.ToString(),
					Value = $"{d.IDDjelatnik}"
				});
			}
		}

		private void AddTim()
		{
			Djelatnik voditelj = Repozitorij.GetDjelatnik(int.Parse(ddlVoditeljProjekta.SelectedValue));
			Tim t = new Tim(tbNaziv.Text, voditelj);

			Repozitorij.AddNewTim(t);
			Response.Redirect("Timovi.aspx");
		}
	}
}