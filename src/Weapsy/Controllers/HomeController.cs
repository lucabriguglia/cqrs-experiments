using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Weapsy.Blog.Bus.Contracts;

namespace Weapsy.Controllers
{
    public class HomeController : Controller
    {
		private readonly ICommandSender _commandSender;

		public HomeController(ICommandSender commandSender)
		{
			_commandSender = commandSender;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}