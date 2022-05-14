using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Repositorio;

public class UsuarioRepositoriotest
{
    private IQueryable<Usuario> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Usuario>
        {
            new Usuario(){Id = 1, Username = "admin", Password = "1234", Nombres = "Jose"},
            new Usuario(){Id = 2, Username = "user1", Password = "1111", Nombres = "Pedro"},
            new Usuario(){Id = 3, Username = "user2", Password = "2222", Nombres = "Luis"},
            new Usuario(){Id = 4, Username = "user3", Password = "3333", Nombres = "Marlon"}
            
        }.AsQueryable();
        
        var mockDbsetUsuario = new MockDbSet<Usuario>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Usuarios).Returns(mockDbsetUsuario.Object);

    }

    [Test]
    public void ObtenerUsuarioRepoTestCaso01()
    {
        var ropositorio = new UsuarioRepositorio(mockDB.Object);

        var result = ropositorio.UsuarioLoguer("admin");
        
        Assert.AreEqual("admin", result.Username);
    }
    
    [Test]
    public void ObtenerUsuarioRepoTestCaso02()
    {
        var ropositorio = new UsuarioRepositorio(mockDB.Object);

        var result = ropositorio.UsuarioLoguer("user1");
        
        Assert.AreEqual("user1", result.Username);
    }
    
    [Test]
    public void ObtenerUsuarioRepoTestCaso03()
    {
        var ropositorio = new UsuarioRepositorio(mockDB.Object);

        var result = ropositorio.UsuarioLoguer("user2");
        
        Assert.AreEqual("user2", result.Username);
    }
    
    [Test]
    public void ObtenerUsuarioRepoErrorTestCaso01()
    {
        var ropositorio = new UsuarioRepositorio(mockDB.Object);

        var result = ropositorio.UsuarioLoguer("user");
        
        Assert.AreEqual("user", result.Username);
    }
}