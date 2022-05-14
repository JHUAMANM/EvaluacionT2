using CalidadT2.Models;

namespace CalidadT2.Repositorio
{
    public interface IComentarioRepositorrio
    {
        Libro AgregandoComentario(Comentario comentario);
    }
    public class ComentarioRepositorio
    {
        private AppBibliotecaContext app;

        public ComentarioRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public Libro AgregandoComentario(Comentario comentario)
        {
          var libro =  app.Comentarios.Add(comentario);

          return new Libro();
        }
    }
}