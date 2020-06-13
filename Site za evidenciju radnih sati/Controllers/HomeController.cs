using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_za_evidenciju_radnih_sati.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[Route("pregled_rada")]
		public ActionResult PregledRada()
		{
			return View();
		}

		[Route("potvrda_satnica")]
		public ActionResult PotvrdaSatnica()
		{
			return View();
		}
	}
}