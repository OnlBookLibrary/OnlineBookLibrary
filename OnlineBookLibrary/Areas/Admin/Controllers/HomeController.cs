using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Extentions;
using OnlineBookLibrary.Models;

namespace OnlineBookLibrary.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]

		[SessionFilter]
		public IActionResult Index()
		{
				return View();
		}
	}
}
