using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Models;
using Ejemplo1.Service;

namespace Ejemplo1.Controllers



{
    public class RegistrarseController : Controller
    {
        private readonly IAPIService _apiService;

        public RegistrarseController(IAPIService apiService)
        {
            _apiService = apiService;
        }





        // GET: RegistrarseControllercs
        public ActionResult Index()
        {
            return View("Registrarse");
        }

        // GET: RegistrarseControllercs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrarseControllercs/Create
        public ActionResult Create()
        {
            return View("RegistroDetails");

        }

        // POST: RegistrarseControllercs/Create
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

        public IActionResult Registrarse()
        {
            return View();
        }
        // POST: RegistrarseControllercs/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrarse(Usuario usuario)
        {
            Usuario user = await _apiService.PostRegistrarse(usuario);

            if (user != null)
            {
                Usuario userLogin = await _apiService.GetIniciarSesion(user.Correo, user.Contrasena);
                
                if(userLogin.Nombre != null)
                    return RedirectToAction("Index", "Producto");//
                else
                    return View();
            }
            else
                return View();
        }
        // GET: RegistrarseControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrarseControllercs/Edit/5
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

        // GET: RegistrarseControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrarseControllercs/Delete/5
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
