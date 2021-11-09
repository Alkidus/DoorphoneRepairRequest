using System;
using Xunit;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void IndexReturnsAViewResultWithAListOfAdresses()
        {
            // Arrange
            var mock = new Mock<IRepository<Adress>>();
            mock.Setup(repo => repo.GetAllList()).Returns(GetTestAdress());
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Adress>>(viewResult.Model);
            Assert.Equal(GetTestAdress().Count, model.Count());
        }
        private List<Adress> GetTestAdress()
        {
            var adresses = new List<Adress>
            {
                new Adress { Id=1, City = "Чернигов", Street = "Шевченко", House = 109, Corpus = "", 
                    Entrance = 3, ContractNumb = "124", FlatCount = 36, DoorsCount = 1, 
                    DomofonSystemId = 1, DomofonKeyId = 1 },
                new Adress { Id=2, City = "Чернигов", Street = "Еськова", House = 4, Corpus = "Б", 
                    Entrance = 4, ContractNumb = "217", FlatCount = 54, DoorsCount = 2, 
                    DomofonSystemId = 2, DomofonKeyId = 2 },
                new Adress { Id=1, City = "Чернигов", Street = "Мстиславского", House = 34, Corpus = "", 
                    Entrance = 3, ContractNumb = "628", FlatCount = 15, DoorsCount = 1, 
                    DomofonSystemId = 3, DomofonKeyId = 3 }
            };
            return adresses;
        }

        [Fact]
        public void AddAdressReturnsViewResultWithAdressModel()
        {
            // Arrange
            var mock = new Mock<IRepository<Adress>>();
            var controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");
            Adress newAdress = new Adress();

            // Act
            var result = controller.AddAdress(newAdress);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);/////////////
            Assert.Equal(newAdress, viewResult?.Model);
        }

        [Fact]
        public void AddAdressReturnsARedirectAndAddsAdress()
        {
            // Arrange
            var mock = new Mock<IRepository<Adress>>();
            var controller = new HomeController(mock.Object);
            var newAdress = new Adress()
            {
                Street = "Шевченко"
            };

            // Act
            var result = controller.AddAdress(newAdress);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Create(newAdress));
        }

        [Fact]
        public void GetAdressReturnsBadRequestResultWhenIdIsNull()
        {
            // Arrange
            var mock = new Mock<IRepository<Adress>>();
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.EditAdressByID(null);

            // Arrange
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetAdressReturnsNotFoundResultWhenAdressNotFound()
        {
            // Arrange
            int testAdressId = 1;
            var mock = new Mock<IRepository<Adress>>();
            mock.Setup(repo => repo.GetByID(testAdressId))
                .Returns(null as Adress);
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.EditAdressByID(testAdressId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetAdressReturnsViewResultWithAdress()
        {
            // Arrange
            int testAdressId = 1;
            var mock = new Mock<IRepository<Adress>>();
            mock.Setup(repo => repo.GetByID(testAdressId))
                .Returns(GetTestAdress().FirstOrDefault(p => p.Id == testAdressId));
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.EditAdressByID(testAdressId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Adress>(viewResult.ViewData.Model);
            Assert.Equal("Шевченко", model.Street);
            Assert.Equal(109, model.House);
            Assert.Equal(testAdressId, model.Id);
        }
    }
}
