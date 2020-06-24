using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site_za_administraciju.Models;

namespace Site_za_evidenciju_radnih_sati.Controllers
{
    public class LoginController : Controller
    {
		public ActionResult Index()
		{
			string btnLoginClick = Request["btnLogin"];
			if ( btnLoginClick == "Login" )
			{
				string email = Request["tbUsername"];
				string password = Request["tbPassword"];

				CheckUserInfo(email, password);
			}

			return View();
		}

		private void CheckUserInfo( string email, string password )
		{
			Djelatnik djelatnik = Repozitorij.LoginUser(email, password);

			if ( djelatnik != null && HasPermission(djelatnik.Tip) )
				LoginUser(djelatnik);
			else
				RedirectToAction(actionName: "Index", controllerName: "Login");
		}

		private void LoginUser( Djelatnik djelatnik )
		{
			Session["djelatnik"] = djelatnik;
			RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		private bool HasPermission( TipDjelatnika tip ) => tip != TipDjelatnika.Neaktivan;
	}
}