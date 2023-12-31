﻿using Ejemplo1.Models;
using Ejemplo1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo1.Controllers
{
	public class IniciarSesionController : Controller

	{
		private readonly IAPIService _apiService;

		public IUserService _userService;

		public bool userLogin { get; set; }

		public IniciarSesionController(IAPIService apiService, IUserService userService)
		{
			_apiService = apiService;
			_userService = userService;
			userLogin = true;

		}



		// GET: IniciarSesion
		public ActionResult Index()

		{
			return View("IniciarSesion");
		}


		public IActionResult IniciarSesion()
		{
			return View();
		}
		// POST: RegistrarseControllercs/Create
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<ActionResult> IniciarSesion(Usuario usuario)
		{

			Usuario userLogin = await _apiService.GetIniciarSesion(usuario.Correo, usuario.Contrasena);

			if (userLogin != null && userLogin.Nombre != null)
			{
				_userService.usuarioGlobal = userLogin;

				if(userLogin.Nombre=="Admin")
				return RedirectToAction("Index", "Producto");

				else
					return RedirectToAction("Index", "Comprar");

			}
			else
				return RedirectToAction("IniciarSesion", "IniciarSesion");

		}

		public IActionResult CerrarSesion()
		{
			_userService.usuarioGlobal = new Usuario();
			return RedirectToAction("IniciarSesion", "IniciarSesion");
		}
		

		// GET: IniciarSesion/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: IniciarSesion/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: IniciarSesion/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: IniciarSesion/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: IniciarSesion/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: IniciarSesion/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: IniciarSesion/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
