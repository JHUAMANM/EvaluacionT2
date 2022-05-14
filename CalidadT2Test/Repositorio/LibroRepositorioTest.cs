using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Repositorio;

public class LibroRepositorioTest
{
    private IQueryable<Libro> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Libro>
        {
            new Libro(){Id = 1, Nombre = "Paco", Imagen = "Lobo", AutorId = 1, Puntaje = 4},
            new Libro(){Id = 2, Nombre = "Pedro", Imagen = "Met",AutorId = 2, Puntaje = 5},
            new Libro(){Id = 3, Nombre = "Machete", Imagen = "Lord",AutorId = 3, Puntaje = 4}
            
        }.AsQueryable();
        
        var mockDbsetLibro = new MockDbSet<Libro>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Libros).Returns(mockDbsetLibro.Object);

    }

    [Test]
    public void ObtenerLibrosRepoTestCaso01()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);

        var result = repositorio.ObtenerTodosLibros();
        
        Assert.AreEqual(3, result.Count);
    }
    
    [Test]
    public void ObtenerLibrosRepoConErrorTestCaso01()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);

        var result = repositorio.ObtenerTodosLibros();
        
        Assert.AreEqual(1, result.Count);
    }
    
    [Test]
    public void ObtenerLibrosPorIdTestCaso01()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);

        var result = repositorio.ObtenetLibroPorId(2);
        
        Assert.AreEqual(2, result.Id);
    }
    
    [Test]
    public void ObtenerLibrosPorIdTestCaso02()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);

        var result = repositorio.ObtenetLibroPorId(3);
        
        Assert.AreEqual(3, result.Id);
    }
    
    [Test]
    public void ObtenerLibrosPorIdTestCaso03()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);

        var result = repositorio.ObtenetLibroPorId(1);
        
        Assert.AreEqual(1, result.Id);
    }
    
    [Test]
    public void ObtenerLibrosErrorPorIdTestCaso01()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);

        var result = repositorio.ObtenetLibroPorId(5);
        
        Assert.AreEqual(3, result.Id);
    }
    
    [Test]
    public void ObtenerLibrosErrorPorIdTestCaso02()
    {
        var repositorio = new LibroRepositorio(mockDB.Object);

        var result = repositorio.ObtenetLibroPorId(4);
        
        Assert.AreEqual(4, result.Id);
    }

}