using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DodajProjekt : System.Web.UI.Page
	{
		protected void Page_Load( object sender, EventArgs e )
		{
			LoadKlijentiDdl();
		}

		private void LoadKlijentiDdl()
		{
			IEnumerable<Klijent> klijenti = Repozitorij.GetKlijenti();
			ddlKlijenti.Items.Clear();

			ddlKlijenti.Items.Add(new ListItem
			{
				Text = "--- odaberi ---",
				Selected = true,
				Value = $"{-1}"
			});

			foreach ( Klijent k in klijenti )
			{
				ddlKlijenti.Items.Add(new ListItem
				{
					Text = k.Naziv,
					Value = k.IDKlijent.ToString()
				});
			}
		}

		protected void BtnDodaj_Click( object sender, EventArgs e )
		{
			AddProjektToDatabase();
			Response.Redirect("Projekti.aspx");
		}

		private void AddProjektToDatabase()
		{
			Projekt p = new Projekt
			(
				naziv: tbNaziv.Text,
				datumOtvaranja: DateTime.Today,
				voditelj: Session["djelatnik"] as Djelatnik,
				klijent: Repozitorij.GetKlijent(int.Parse(ddlKlijenti.SelectedValue)),
				opisProjekta: tbOpis.Text
			);

			Repozitorij.AddNewProjekt(p);
		}
	}
}