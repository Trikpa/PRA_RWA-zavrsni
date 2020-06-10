using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_za_administraciju.Models;

namespace Site_za_administraciju
{
	public partial class DetaljiKlijenta : System.Web.UI.Page
	{
		private Klijent k;
		IEnumerable<Projekt> projektiKlijenta;
		protected void Page_Load( object sender, EventArgs e )
		{
			if ( Request.QueryString["id"] == null || Session["djelatnik"] == null )
				Response.Redirect("Login.aspx");
			else
			{
				int klijentID = int.Parse(Request.QueryString["id"]);
				k = Repozitorij.GetKlijent(klijentID);
				if ( !IsPostBack )
					FillForm();
				LoadProjektiKlijenta();
			}
		}

		private void FillForm()
		{
			tbNaziv.Text = k.Naziv;
			tbTelefon.Text = k.Telefon;
			tbEmail.Text = k.Email;

			
		}

		private void LoadProjektiKlijenta()
		{
			projektiKlijenta = Repozitorij.GetProjektiKlijenta(k);
			foreach ( Projekt projekt in projektiKlijenta )
			{
				ProjektUserControl puc = LoadControl("User_Controls/ProjektUserControl.ascx") as ProjektUserControl;
				puc.ID = $"{projekt.IDProjekt}";
				puc.SetInfo(projekt);
				phProjektiKlijenta.Controls.Add(puc);
			}
		}
		protected void BtnSpremi_Click( object sender, EventArgs e ) => UpdateKlijent();

		private void UpdateKlijent()
		{
			k.Naziv = tbNaziv.Text;
			k.Telefon = tbTelefon.Text;
			k.Email = tbEmail.Text;

			Repozitorij.UpdateKlijent(k);

			ChangeTextBoxFieldsState(enabled: false);
		}

		protected void BtnPovratak_Click( object sender, EventArgs e ) => Response.Redirect("Klijenti.aspx");
		protected void BtnUredi_Click( object sender, EventArgs e ) => ChangeTextBoxFieldsState(enabled: true);

		private void ChangeTextBoxFieldsState( bool enabled )
		{
			tbNaziv.Enabled = enabled;
			tbTelefon.Enabled = enabled;
			tbEmail.Enabled = enabled;
		}
	}
}