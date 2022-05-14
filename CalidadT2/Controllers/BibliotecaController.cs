using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly AppBibliotecaContext app;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public BibliotecaController(AppBibliotecaContext app, IUsuarioRepositorio usuarioRepositorio, IBibliotecaRepositorio bibliotecaRepositorio)
        {
            this.app = app;
            _usuarioRepositorio = usuarioRepositorio;
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var model = _bibliotecaRepositorio.ObtenerTodoDeBiblioteca(user.Id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();

            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            _bibliotecaRepositorio.AgregarLibroBiblioteca(biblioteca);

           //TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();

            _bibliotecaRepositorio.ActualizarEstadoDeBiblioteca(libroId, user.Id);

            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

           _bibliotecaRepositorio.MarcarTerminadoEstado(libroId, user.Id);

           //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var user = claim.Value;
            return _usuarioRepositorio.UsuarioLoguer(user);
        }
    }
}
