using System;
using System.Linq;
using System.Security.Claims;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly AppBibliotecaContext app;
        private readonly ILibroRepositorio _libroRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LibroController(AppBibliotecaContext app, ILibroRepositorio libroRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            this.app = app;
            _libroRepositorio = libroRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _libroRepositorio.ObtenetLibroPorId(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            
            _libroRepositorio.AgregarComentario(comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var user = claim.Value;
            return _usuarioRepositorio.UsuarioLoguer(user);
        }
    }
}
