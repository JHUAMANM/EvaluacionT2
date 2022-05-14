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

public class LibroControllerTest
{
   
    [Test]
    public void DetalleLibroTestCaso01()
    {
        var mockDetalle = new Mock<ILibroRepositorio>();
        
        var controller = new LibroController(null, mockDetalle.Object, null);

        var view = (ViewResult) controller.Details(2);
        
        Assert.IsNotNull(view);
        
        Assert.IsInstanceOf<ViewResult>(view);
    }

    [Test]
    public void AddComentarioTestCaso01()
    {
        var mockClaimPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimPrincipal.Setup(o => o.Claims).Returns(new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "admin")
        });
        
        var mockContex = new Mock<HttpContext>();
        mockContex.Setup(o => o.User).Returns(mockClaimPrincipal.Object);

        var mockUsuarioRepo = new Mock<IUsuarioRepositorio>();
        mockUsuarioRepo.Setup(o => o.UsuarioLoguer("admin")).Returns(new Usuario());

        var mockLibroRepo = new Mock<ILibroRepositorio>();
        
            
        var controller = new LibroController(null, mockLibroRepo.Object, mockUsuarioRepo.Object);

        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContex.Object
        };

        var view = controller.AddComentario(new Comentario(){LibroId = 1, Puntaje = 5});
        
        Assert.IsNotNull(view);
       
    }
    
}