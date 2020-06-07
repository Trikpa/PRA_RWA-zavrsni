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
	public partial class Login : System.Web.UI.Page
	{
		public string email { get; set; }
		public string password { get; set; }

		private const string SITE_ZA_ADMINISTRACIJU = "administracija";
		private const string SITE_ZA_EVIDENCIJU = "evidencija";

		protected void Page_Load( object sender, EventArgs e )
		{
			
		}

		protected void BtnLogin_Click( object sender, EventArgs e )
		{
			email = tbUsername.Text;
			password = tbPassword.Text;
			CheckUserInfo(email, password);
		}

		private void CheckUserInfo( string email, string password )
		{
			Djelatnik djelatnik = Repozitorij.LoginUser(email, password);

			if ( djelatnik == null )
			{
				DisplayErrorMessage("Incorrect username or password");
				return;
			}

			if ( HasPermission(djelatnik.Tip) )
				LoginUser(djelatnik);
			else
				DisplayErrorMessage("You don't have permission to enter the selected site");
		}

		private void LoginUser( Djelatnik djelatnik )
		{
			if ( cbRememberMe.Checked )
				CreateEmailPasswordCookies();
			Session["djelatnik"] = djelatnik;

			switch ( ddlOdabraniSite.SelectedValue )
			{
				case SITE_ZA_EVIDENCIJU:
					//Response.Redirect("~Projekti.aspx");
					break;
				case SITE_ZA_ADMINISTRACIJU:
					Response.Redirect("Projekti.aspx");
					break;
			}
		}

		private void DisplayErrorMessage( string message )
		{
			errorMessage.Text = message;
			errorMessage.Visible = true;
		}

		private bool HasPermission( TipDjelatnika tip )
		{
			if ( ddlOdabraniSite.SelectedValue == SITE_ZA_ADMINISTRACIJU )
			{
				if ( tip == TipDjelatnika.Direktor || tip == TipDjelatnika.VoditeljTima )
					return true;

				return false;
			}
			if ( ddlOdabraniSite.SelectedValue == SITE_ZA_EVIDENCIJU )
				if ( tip != TipDjelatnika.Neaktivan )
					return true;

			return false;
		}

		private void CreateEmailPasswordCookies()
		{
			HttpCookie emailCookie = new HttpCookie("email", email);
			HttpCookie passwordCookie = new HttpCookie("password", password);

			emailCookie.Expires = DateTime.Now.AddMinutes(30);
			passwordCookie.Expires = DateTime.Now.AddMinutes(30);

			Response.AppendCookie(emailCookie);
			Response.AppendCookie(passwordCookie);
		}
	}
}