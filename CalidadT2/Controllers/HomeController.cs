using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private AppBibliotecaContext app;
        private ILibroRepositorio _libroRepositorio;
        public HomeController(AppBibliotecaContext app, ILibroRepositorio libroRepositorio)
        {
            this.app = app;
            this._libroRepositorio = libroRepositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _libroRepositorio.ObtenerTodosLibros();
            return View(model);
        }
    }
}
