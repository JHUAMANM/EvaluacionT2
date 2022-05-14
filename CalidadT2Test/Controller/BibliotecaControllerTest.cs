using System.Collections.Generic;
using System.Security.Claims;
using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Controller;

public class BibliotecaControllerTest
{
 
    [Test]
    public void IndexViewTestCase01()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUsuarioRepositorio>();
        mockUserRepo.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var controller = new BibliotecaController(null, mockUserRepo.Object, null);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var redirect = controller.Index;

        Assert.IsNotNull(redirect);
    }
    
    
    [Test]
    public void AddViewTestCase01()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUsuarioRepositorio>();
        mockUserRepo.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var mockBibliotecaRepo = new Mock<IBibliotecaRepositorio>();

        var controller = new BibliotecaController(null, mockUserRepo.Object, mockBibliotecaRepo.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var view = controller.Add(1);

        Assert.IsNotNull(view);
    }
    
    
    [Test]
    public void MarcarComoLeyendoViewTestCase01()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUsuarioRepositorio>();
        mockUserRepo.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var mockBibliotecaRepo = new Mock<IBibliotecaRepositorio>();

        var controller = new BibliotecaController(null, mockUserRepo.Object, mockBibliotecaRepo.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var view = controller.MarcarComoLeyendo(1);

        Assert.IsNotNull(view);
    }
    
    [Test]
    public void MarcarComoTerminadoTestCase01()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUsuarioRepositorio>();
        mockUserRepo.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var mockBibliotecaRepo = new Mock<IBibliotecaRepositorio>();
        
       var controller = new BibliotecaController(null, mockUserRepo.Object, mockBibliotecaRepo.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var view = controller.MarcarComoTerminado(1);

        Assert.IsNotNull(view);
        
       
    }
}