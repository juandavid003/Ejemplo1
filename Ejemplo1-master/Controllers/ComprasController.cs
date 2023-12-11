using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;
using Ejemplo1.Models;
using Ejemplo1.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ejemplo1.Controllers
{
    public class ComprasController : Controller
    {

        private readonly IAPIService _apiService;

        public IUserService _userService;
        public List<SelectListItem> items { get; set; }

        public ComprasController(IAPIService apiService, IUserService userService)
        {
            _apiService = apiService;
            _userService = userService;
        }



        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Compra> compras = await _apiService.GetCompras();
            return View(compras);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdProducto)
        {
            Producto producto = await _apiService.GetProducto(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {
            List<Producto> productos = await _apiService.GetProductos();
            items = new List<SelectListItem>();

            foreach (var item in productos)
            {
                items.Add(new SelectListItem { Value = item.IdProducto.ToString(), Text = item.Nombre });
            }

            var model = new Compra
            {
                SelectList = items
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Compra compra)
        {

            compra.Nombre = _userService.usuarioGlobal.Nombre;
            Compra compraObj = await _apiService.PostCompra(compra);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {
            Producto producto = await _apiService.GetProducto(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            Producto producto2 = await _apiService.GetProducto(producto.IdProducto);
            if (producto2 != null)
            {
                Producto producto3 = await _apiService.PutProducto(producto.IdProducto, producto);

                return RedirectToAction("Index");
            }
            return View();
        }




        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(Compra compra)
        {
            Boolean producto2 = await _apiService.DeleteCompra(compra.IdCompra);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }



    }
}
    