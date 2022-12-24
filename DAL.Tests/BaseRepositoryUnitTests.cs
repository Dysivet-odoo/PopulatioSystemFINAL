using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using PopControl.DALL.EF;
using PopControl.DALL.Entities;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputStorageInstance_CalledAddMethodOfSetWithStreetInstance()
        {

            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StatsContext>().Options;
            var mockContext = new Mock<StatsContext>(opt);
            var mockDbSet = new Mock<DbSet<Statistics>>();
            mockContext
               .Setup(context =>
                    context.Set<Statistics>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestStatisticRepository(mockContext.Object);
            Statistics expextedStat = new Mock<Statistics>().Object;
            // Act
            repository.Create(expextedStat);
            // Assert
            mockDbSet.Verify(dbSet=>dbSet.Add(expextedStat), Times.Once());
        }
        
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StatsContext>().Options;
            var mockContext = new Mock<StatsContext>(opt);
            var mockDbSet = new Mock<DbSet<Statistics>>();
            mockContext.Setup(context => context.Set<Statistics>()).Returns(mockDbSet.Object);

            var expectedStatistic = new Statistics { IdStatistic = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStatistic.IdStatistic)).Returns(expectedStatistic);
            var repository = new TestStatisticRepository(mockContext.Object);

            //Act
            var actualStorage = repository.Get(expectedStatistic.IdStatistic);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStatistic.IdStatistic), Times.Once());
            Assert.Equal(expectedStatistic, actualStorage);
        }
        
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StatsContext>().Options;
            var mockContext = new Mock<StatsContext>(opt);
            var mockDbSet = new Mock<DbSet<Statistics>>();
            mockContext.Setup(context => context.Set<Statistics>()).Returns(mockDbSet.Object);
            var repository = new TestStatisticRepository(mockContext.Object);
            Statistics expectedStatistic = new Statistics() { IdStatistic = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStatistic.IdStatistic)).Returns(expectedStatistic);

            // Act
            repository.Delete(expectedStatistic.IdStatistic);

            // assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStatistic.IdStatistic), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedStatistic), Times.Once());
        }
    }
}
