using Ejemplo1.Models;

namespace Ejemplo1.Service
{
    public class UserService : IUserService
	{
        public Usuario usuarioGlobal { get; set; }
        public UserService()
        {
            usuarioGlobal = new Usuario();
        }

    }
}
