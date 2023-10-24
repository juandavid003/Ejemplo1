﻿using Ejemplo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo1.Controllers
{
    public class IniciarSesionController : Controller
    {
        // GET: IniciarSesion
        public ActionResult Index()
        {
            return View("InicioSesionDetails");
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