using NGnono.FMNote.WebSite4App.Core.Controllers;
using NUnit.Framework;
using System.Web.Mvc;

namespace NGnono.FMNote.WebSite4App.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.That("Modify this template to jump-start your ASP.NET MVC application.", Is.EqualTo(result.ViewBag.Message));
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
