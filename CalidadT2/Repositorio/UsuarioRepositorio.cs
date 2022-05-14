using System.Linq;
using CalidadT2.Models;

namespace CalidadT2.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario UsuarioLoguer(string user);
    }

    public class UsuarioRepositorio: IUsuarioRepositorio

    {
        private readonly AppBibliotecaContext app;

        public UsuarioRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }
        public Usuario UsuarioLoguer(string user)
        {
           return app.Usuarios.Where(o => o.Username == user).FirstOrDefault();
           
        }

    }
}