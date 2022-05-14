using System.Collections.Generic;
using System.Linq;
using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Repositorio
{
    public interface IBibliotecaRepositorio
    {
        List<Biblioteca> ObtenerTodoDeBiblioteca(int id);
        Biblioteca AgregarLibroBiblioteca(Biblioteca biblioteca);
        Biblioteca ActualizarEstadoDeBiblioteca(int LibroId, int UsuarioId);
        Biblioteca MarcarTerminadoEstado(int LibroId, int id);
    }
    public class BibliotecaRepositorio: IBibliotecaRepositorio
    {
        private AppBibliotecaContext app;

        public BibliotecaRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public List<Biblioteca> ObtenerTodoDeBiblioteca(int id)
        {
          return app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == id)
                .ToList();
        }

        public Biblioteca AgregarLibroBiblioteca(Biblioteca biblioteca)
        {
            app.Bibliotecas.Add(biblioteca);
            app.SaveChanges();

            return biblioteca;
        }

        public Biblioteca ActualizarEstadoDeBiblioteca(int LibroId, int UsuarioId)
        {
           var libro = app.Bibliotecas
                .Where(o => o.LibroId == LibroId && o.UsuarioId == UsuarioId)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            app.SaveChanges();
            
            
            return libro;
        }


        public Biblioteca MarcarTerminadoEstado(int LibroId, int id)
        {
            var libro = app.Bibliotecas
                .Where(o => o.LibroId == LibroId && o.UsuarioId == id)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            
            app.SaveChanges();

            return libro;

        }

    }
}