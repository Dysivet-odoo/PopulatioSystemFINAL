using Xunit;
using System;
using PopControl.DALL.UnitOfWork;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CLL.Security;
using CLL.Security.Identity;
using PopControl.DALL.Entities;
using PopControl.DALL.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;

namespace BLL.Tests
{
    public class HumanServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new HumanService(nullUnitOfWork)
            );
        }
        [Fact]
        public void GetHuman_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1,"Oleksandr","Petrov","admin12","sekfh@mail");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IHumanService humanService = new HumanService(mockUnitOfWork.Object);
            Assert.Throws<MethodAccessException>(() => humanService.GetHumans(0));
        }

        IHumanService GetHumanService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedHuman = new Human()
            {
                IdHuman=1,
                Name = "Petro",
                Surname="Ivanov",
                Age=32,
                Sex=Sex.Male
            };
            var mockDbSet = new Mock<IHumanRepository>();
            mockDbSet
              .Setup(z =>
                z.Find(
                    It.IsAny<Func<Human, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                 .Returns(
                     new List<Human>() { expectedHuman }
                  );
            mockContext
                .Setup(context =>
                    context.Humans)
                .Returns(mockDbSet.Object);
            IHumanService streetService = new HumanService(mockContext.Object);
            return streetService;
        }

        [Fact]
        public void GetHuman_HumanFromDAL_CorrectMappingToHumanDTO()
        {
            // Arrange
            User user = new Analytik(1, "Petro", "Ivanov", "analytic1", "bjiei@mail");
            SecurityContext.SetUser(user);
            var humanService = GetHumanService();
            var actualHumanDto = humanService.GetHumans(0).First();
            
            Assert.True(actualHumanDto);
        }
    }
}