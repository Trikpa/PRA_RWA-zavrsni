using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Site_za_evidenciju_radnih_sati
{
	public class RouteConfig
	{
		public static void RegisterRoutes( RouteCollection routes )
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "",
				defaults: new { controller = "Login", action = "Index" }
			);
			
			routes.MapRoute(
				name: "Home",
				url: "{controller}",
				defaults: new { controller = "Home", action = "Index" }
			);
			
			routes.MapRoute(
				name: "PregledRada",
				url: "{controller}/",
				defaults: new { controller = "PregledRada", action = "Index" }
			);
			
			routes.MapRoute(
				name: "PotvrdaSatnica",
				url: "{controller}/",
				defaults: new { controller = "PotvrdaSatnica", action = "Index" }
			);
		}
	}
}
