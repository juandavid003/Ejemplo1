using Ejemplo1.Models;

namespace Ejemplo1.Service
{
    public interface IAPIService
    {
        public Task<List<Producto>> GetProductos();

        public Task<Producto> GetProducto(int id);
        public Task<Producto> PostProducto(Producto producto);
        public Task<Producto> PutProducto(int IdProducto, Producto producto);
        public Task<Boolean> DeleteProducto(int IdProducto);
        public Task<Usuario> GetIniciarSesion(String usuario, String Contrasena);
        public Task<Usuario> PostRegistrarse(Usuario usuario);





    }
}
