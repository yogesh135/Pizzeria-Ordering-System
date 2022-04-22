using Microsoft.AspNetCore.Mvc;
using Moq;
using Pizzeria_Ordering_System.Contract;
using Pizzeria_Ordering_System.Controllers;
using Pizzeria_Ordering_System.Persistence.CustomException;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Pizzeria_Ordering_System.UnitTest.Controller
{
    public class PizzaOrderControllerUnitTest
    {
        Mock<IPizzaOrderRepository> mockPizzaOrderRepository = null;
        PizzaOrderController controller;

        public PizzaOrderControllerUnitTest()
        {
            mockPizzaOrderRepository = new Mock<IPizzaOrderRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            controller = new PizzaOrderController(mockPizzaOrderRepository.Object);

        }

        [Fact]
        public async Task GetAllPizzas()
        {
            // Arrange
            var result = new List<Pizza>() {
                 new Pizza() {
                    Id = 1,
                    Name = "Veggie",
                    Description = "Veggie Pizza for vegitarians",
                    Price = 100,
                    ImageUrl = "",
                    Constituents = new List<Constituents>()
                    {
                        new Constituents()
                        {
                            Id = 1,
                            Name = "Cheese"
                        }
                    }
                 }
            };

            mockPizzaOrderRepository.Setup(x => x.GetOrderedPizzaAsync()).ReturnsAsync(result);

            // Act
            var actualResult = await controller.GetAllPizzas();

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task GetPizzaById()
        {
            // Arrange
            var result = new Pizza()
            {
                Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                Constituents = new List<Constituents>()
                    {
                        new Constituents()
                        {
                            Id = 1,
                            Name = "Cheese"
                        }
                    }
            };

            mockPizzaOrderRepository.Setup(x => x.GetPizzaByIdAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actualResult = await controller.GetPizzaById(1);

            // Assert
            Assert.NotNull(actualResult);
        }


        [Fact]
        public void GetPizzaById_Throw_Exception()
        {
            // Arrange
            mockPizzaOrderRepository.Setup(x => x.GetPizzaByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new ArgumentNullException("pizzaId can not be zero"));

            // assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.GetPizzaById(1));
        }


        [Fact]
        public async Task BakeCustomizedPizzas_CreatePizza()
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

            mockPizzaOrderRepository.Setup(x => x.CustomizedPizzaOrder(It.IsAny<PizzaOrderRequest>()))
                .ReturnsAsync(new PizzaOrderResponse()
                {
                    OrderId = 1,
                    PizzaId = 1,
                    Count = 1,
                    Price = 210,
                    PizzaName = "Veggie"
                });

            // Act
            var result = await controller.BakeCustomizedPizza(request);

            // Assert
            Assert.NotNull(result);
            var res = result as OkObjectResult;
            Assert.Equal(res?.StatusCode, (int)HttpStatusCode.OK);
            mockPizzaOrderRepository.VerifyAll();
        }

        [Fact]
        public void CustomizedPizzaOrder_ThrowsException_NotValidRequest()
        {
            // Arrange
            mockPizzaOrderRepository.Setup(x => x.CustomizedPizzaOrder(It.IsAny<PizzaOrderRequest>()))
                .ThrowsAsync(new ArgumentNullException("please select pizza"));

            // assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.BakeCustomizedPizza(null));
        }

        [Fact]
        public async Task CreateSelectedPizzaOrder_CreatePizza()
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

            mockPizzaOrderRepository.Setup(x => x.CreatePizzaOrder(It.IsAny<PizzaOrderRequest>(),
                 It.IsAny<int>()))
                .ReturnsAsync(new PizzaOrderResponse()
                {
                    OrderId = 1,
                    PizzaId = 1,
                    Count = 1,
                    Price = 210,
                    PizzaName = "Veggie"

                });

            // Act
            var result = await controller.BakePizza(request, 1);

            // Assert
            Assert.NotNull(result);
            var res = result as OkObjectResult;
            Assert.Equal(res?.StatusCode, (int)HttpStatusCode.OK);
            mockPizzaOrderRepository.VerifyAll();
        }

        [Fact]
        public void CreateSelectPizzaOrder_Throw_Not_Found_Exception()
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

            mockPizzaOrderRepository.Setup(x => x.CreatePizzaOrder(It.IsAny<PizzaOrderRequest>(),
                  It.IsAny<int>()))
                 .ThrowsAsync(new PizzaNotFoundException("selected pizza not found"));

            // assert
            Assert.ThrowsAsync<PizzaNotFoundException>(async () => await controller.BakePizza(request, 10));
        }

        [Fact]
        public void CreateSelectPizzaOrder_Throw__Exception_Request_NotValid()
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

            mockPizzaOrderRepository.Setup(x => x.CreatePizzaOrder(It.IsAny<PizzaOrderRequest>(),
                  It.IsAny<int>()))
                 .ThrowsAsync(new ArgumentNullException("pizzaId not null"));

            // assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.BakePizza(request, 0));
        }
    }
}
