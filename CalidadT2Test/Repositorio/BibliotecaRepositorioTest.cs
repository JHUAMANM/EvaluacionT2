using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Repositorio;

public class BibliotecaRepositorioTest
{
    private IQueryable<Biblioteca> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Biblioteca>
        {
            new Biblioteca(){Id = 1, UsuarioId = 1, LibroId = 1, Estado = 1},
            new Biblioteca(){Id = 2, UsuarioId = 2, LibroId = 2, Estado = 2},
            new Biblioteca(){Id = 3, UsuarioId = 3, LibroId = 3, Estado = 1}
            
        }.AsQueryable();
        
        var mockDbsetBiblioteca = new MockDbSet<Biblioteca>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Bibliotecas).Returns(mockDbsetBiblioteca.Object);

    }

    [Test]
    public void ObtenerBibliotecaRepoTestCaso01()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);

        var result = repositorio.ObtenerTodoDeBiblioteca(1);
        
        Assert.AreEqual(1, result.Count);
    }
    
    [Test]
    public void ObtenerBibliotecaRepoTestCaso02()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);

        var result = repositorio.ObtenerTodoDeBiblioteca(3);
        
        Assert.AreEqual(1, result.Count);
    }
    
    [Test]
    public void AgregarBibliotecaRepoTestCase01()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var result = repositorio.AgregarLibroBiblioteca(new Biblioteca() { Id = 3, UsuarioId = 2, LibroId = 1 });

        Assert.AreEqual(3, result.Id);
    }
    
    [Test]
    public void AgregarBibliotecaRepoTestCase02()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var result = repositorio.AgregarLibroBiblioteca(new Biblioteca() { Id = 3, UsuarioId = 1, LibroId = 1 });

        Assert.AreEqual(3, result.Id);
    }
    
    [Test]
    public void MarcarComoTerminadoRepoTestCase01()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var result = repositorio.ActualizarEstadoDeBiblioteca(1,1);

        Assert.AreEqual(1, result.Id);
    }
    
    [Test]
    public void MarcarComoTerminadoRepoTestCase02()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var result = repositorio.ActualizarEstadoDeBiblioteca(2,2);

        Assert.AreEqual(2, result.Id);
    }
    
    [Test]
    public void MarcarComoTerminadoRepoTestCase03()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var result = repositorio.ActualizarEstadoDeBiblioteca(3,3);

        Assert.AreEqual(3, result.Id);
    }
    
    [Test]
    public void ActualizarEstadoRepoTestCase01()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var result = repositorio.MarcarTerminadoEstado(2,2);

        Assert.AreEqual(2, result.Id);
    }
    
    [Test]
    public void ActualizarEstadoRepoTestCase02()
    {
        var repositorio = new BibliotecaRepositorio(mockDB.Object);
        var result = repositorio.MarcarTerminadoEstado(1,1);

        Assert.AreEqual(1, result.Id);
    }
}