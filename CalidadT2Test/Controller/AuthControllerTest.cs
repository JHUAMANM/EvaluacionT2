using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Controller;

public class AuthControllerTest
{
    [Test]
    public void LoginGet()
    {
        var controller = new AuthController(null);

        var view = (ViewResult) controller.Login();
        
        Assert.IsNotNull(view);
        Assert.IsInstanceOf<ViewResult>(view);
    }
}