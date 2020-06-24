using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site_za_administraciju.Models;

namespace Site_za_evidenciju_radnih_sati.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
            return View();
        }
		//private void CreateEmailPasswordCookies()
		//{
		//	HttpCookie emailCookie = new HttpCookie("email", email);
		//	HttpCookie passwordCookie = new HttpCookie("password", password);

		//	emailCookie.Expires = DateTime.Now.AddMinutes(30);
		//	passwordCookie.Expires = DateTime.Now.AddMinutes(30);

		//	Response.AppendCookie(emailCookie);
		//	Response.AppendCookie(passwordCookie);
		//}
	}
}