using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CLL.Security;
using CLL.Security.Identity;
using PopControl.DALL.UnitOfWork;
using PopControl.DALL.Entities;
using PopControl.DALL.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


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

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => humanService.GetHumans(0));
        }
        [Fact]
        public void GetHuman_HumanFromDAL_CorrectMappingToHumanDTO()
        {
            // Arrange
            User user = new Analytik(1, "Petro", "Ivanov", "analytic1", "bjiei@mail");
            SecurityContext.SetUser(user);
            var humanService = GetHumanService();

            // Act
            var actualHumanDto = humanService.GetHumans(1).First();
            
            // Assert
            Assert.True(
                actualHumanDto.IdHuman == 1
                && actualHumanDto.Name == "Petro"
                && actualHumanDto.Surname == "Ivanov"
                && actualHumanDto.Age == 32
                && actualHumanDto.Sex == DTO.Sex.Male
                );
        }
        IHumanService GetHumanService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedHuman = new Human()
            {
                IdHuman = 1,
                Name = "Petro",
                Surname = "Ivanov",
                Age = 32,
                Sex = Sex.Male
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
    }
}