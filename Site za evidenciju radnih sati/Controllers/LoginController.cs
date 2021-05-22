using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site_za_administraciju.Models;
using Site_za_evidenciju_radnih_sati.Models;

namespace Site_za_evidenciju_radnih_sati.Controllers
{
    public class LoginController : Controller
    {
		public ActionResult Login()
		{
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login( LoginViewModel user )
		{
			if ( ModelState.IsValid )
			{
				Djelatnik djelatnik = Repozitorij.LoginUser(user.Email, user.Password);
				if ( djelatnik != null && HasPermission(djelatnik.Tip) )
				{
					Session["djelatnik"] = djelatnik;
					return RedirectToAction("Index", "Home");
				}
				else
					ViewData["Message"] = "Neispravno korisničko ime ili lozinka ili nemate prava pristupa.";
			}

			return View(user);
		}

		private bool HasPermission( TipDjelatnika tip ) => tip != TipDjelatnika.Neaktivan;
	}
}