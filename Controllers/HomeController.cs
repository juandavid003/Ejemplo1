﻿using Ejemplo1.Models;
using Ejemplo1.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejemplo1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public readonly IUserService _userService;


		public HomeController(ILogger<HomeController> logger, IUserService userService)
		{
			_logger = logger;
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}