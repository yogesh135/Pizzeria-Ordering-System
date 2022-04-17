using Moq;
using Pizzeria_Ordering_System.Contract;
using Pizzeria_Ordering_System.Persistence;
using Pizzeria_Ordering_System.Repository.Implementations;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pizzeria_Ordering_System.UnitTest.Repository
{
    public class PizzaOrderRepositoryUnitTest
    {
        public IPizzaOrderRepository pizzaOrderRepository = null;
        public Mock<IDataStoreRepository> mockDataStoreRespository = null;
        public Mock<IPizzeriaBuilder> mockPizzeriaBuilder = null;

        public PizzaOrderRepositoryUnitTest()
        {
            mockDataStoreRespository = new Mock<IDataStoreRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            mockPizzeriaBuilder = new Mock<IPizzeriaBuilder>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            pizzaOrderRepository = new PizzaOrderRepository(mockDataStoreRespository.Object, mockPizzeriaBuilder.Object);
        }

        [Fact]
        public async Task CreatePizzaOrder_ValidData_Success()
        {
            // Arrange
            var request = new PizzaOrderRequest()
            {
                Name = "Veggie",
                IsAddCheese = true,
                IsAddExtraCheese = true,
                Size = 1,
                NumberOfPizza = 1,
                PizzaConstituentsId = new List<int>() {
                    1,2
                }
            };

            var data = new DataTransfer.Pizza
            {
                Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                CategoriesId = 1,
                PizzaConstituents = new List<DataTransfer.PizzaConstituents>()
                    {
                        new DataTransfer.PizzaConstituents()
                        {
                            ConstituentId = 1,
                            PizzaId = 1
                        }
                    }
            };

            mockDataStoreRespository.Setup(x => x.GetPizzaByIdAsync(1)).ReturnsAsync(data);
            mockDataStoreRespository.Setup(x => x.SavePizzaAsync(It.IsAny<DataTransfer.Pizza>())).ReturnsAsync(1);

            // Act
            var result = await pizzaOrderRepository.CreatePizzaOrder(request, 1).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.Equal(10, result.OrderId);
            mockPizzeriaBuilder.Verify(x => x.CreateAvailablePizza(It.IsAny<DataTransfer.Pizza>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddPizzaSize(It.IsAny<DataTransfer.PizzaSize>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddPizzaCheese(), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddExtraCheeseOnPizza(), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddConstituentsToPizza(It.IsAny<DataTransfer.Constituents>()), Times.AtLeast(2));
            mockPizzeriaBuilder.Verify(x => x.AddCountOfPizza(It.IsAny<int>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.BakePizza(), Times.Once);
        }

        [Fact]
        public async void GetPizzasByIdAsync__InvalidData_ThrowsException()
        {
            // assert
            await Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await pizzaOrderRepository.GetPizzaByIdAsync(0));
        }

        [Fact]
        public async Task CustomizedPizzaOrder_ValidData_Success()
        {
            // Arrange
            var data = new List<DataTransfer.Pizza>() {
             new DataTransfer.Pizza
            {
                Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                CategoriesId = 1,
                PizzaConstituents = new List<DataTransfer.PizzaConstituents>()
                    {
                        new DataTransfer.PizzaConstituents()
                        {
                            ConstituentId = 1,
                            PizzaId = 1
                        }
                    }
            }};

            var request = new PizzaOrderRequest()
            {
                Name = "Veggie",
                IsAddCheese = true,
                IsAddExtraCheese = true,
                Size = 1,
                NumberOfPizza = 1,
                PizzaConstituentsId = new List<int>() {
                    1,2
                }
            };

            mockDataStoreRespository.Setup(x => x.SavePizzaAsync(It.IsAny<DataTransfer.Pizza>())).ReturnsAsync(1);

            // Act
            var result = await pizzaOrderRepository.CustomizedPizzaOrder(request);

            // Assert
            Assert.NotNull(result);
            mockDataStoreRespository.Verify(x => x.SavePizzaAsync(It.IsAny<DataTransfer.Pizza>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.CustomizedPizzaBase(It.IsAny<string>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddPizzaSize(It.IsAny<DataTransfer.PizzaSize>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddPizzaSize(It.IsAny<DataTransfer.PizzaSize>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddExtraCheeseOnPizza(), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.AddConstituentsToPizza(It.IsAny<DataTransfer.Constituents>()), Times.AtLeast(2));
            mockPizzeriaBuilder.Verify(x => x.AddCountOfPizza(It.IsAny<int>()), Times.Once);
            mockPizzeriaBuilder.Verify(x => x.BakePizza(), Times.Once);
        }
    }
}
