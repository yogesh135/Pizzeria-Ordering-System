using Moq;
using Pizzeria_Ordering_System.Controllers;
using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.DataTransfer.Enum;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pizzeria_Ordering_System.UnitTest.Controller
{
    public class ConstituentsControllerUnitTest
    {
        Mock<IConstituentsRepository> mockConstituentsRepository = null;
        ConstituentsController controller;

        public ConstituentsControllerUnitTest()
        {
            mockConstituentsRepository = new Mock<IConstituentsRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            controller = new ConstituentsController(mockConstituentsRepository.Object);

        }

        [Fact]
        public async Task GetAllConstituents_ValidData_Success()
        {
            // Arrange
            var data = new List<Constituents>() {
             new Constituents(){
                 Id = 1,
                 Name ="Grilled Mushrooms",
             }};

            mockConstituentsRepository.Setup(x => x.GetAllConstituentsAsync()).ReturnsAsync(data);

            // Act
            var result = await controller.GetAllConstituents();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllConstituentsType_ValidData_Success()
        {
            // Arrange
            var data = new List<ConstituentsType>() {
             new ConstituentsType(){
                 Id = 1,
                 Name ="Crust",
             }};

            mockConstituentsRepository.Setup(x => x.GetAllConstituentTypesAsync()).ReturnsAsync(data);

            // Act
            var result = await controller.GetAllConstituentsType();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetConstituentType_ValidData_Success()
        {
            // Arrange
            var result = new List<Constituents>() {
             new Constituents(){
                 Id = 1,
                 Name ="Grilled Mushrooms",
             }};

            mockConstituentsRepository.Setup(x => x.GetConstituentByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(result);

            // Act
            var actualResult = await controller.GetConstituentType(1);

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public void GetConstituentByTypeId_Throw_Exception()
        {
            // Arrange
            mockConstituentsRepository.Setup(x => x.GetConstituentByTypeIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new ArgumentNullException("typeId can not be zero"));

            // assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.GetConstituentType(1));
        }

        [Fact]
        public async Task GetPizzaSize_ValidData_Success()
        {
            // Arrange
            var data = new List<PizzaSize>() {
             new PizzaSize(){
                 Id = 1,
                 Name = SizeType.Small,
             }};

            mockConstituentsRepository.Setup(x => x.GetPizzaSizeAsync()).ReturnsAsync(data);

            // act
            var result = await controller.GetPizzaSize();

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetToppings_Sucess_Scenario()
        {
            // Arrange
            var data = new List<Constituents>() {
             new Constituents(){
                 Id = 1,
                 Name ="Pepper Barbecue Chicken",
             }};

            mockConstituentsRepository.Setup(x => x.GetConstituentByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(data);

            // Act
            var actualResult = await controller.GetToppings();

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task GetSauce_Valid_Scenario()
        {
            // Arrange
            var data = new List<Constituents>() {
             new Constituents(){
                 Id = 1,
                 Name ="White Garlic Sauce",
             }};

            mockConstituentsRepository.Setup(x => x.GetConstituentByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(data);

            // Act
            var actualResult = await controller.GetPizzaSauce();

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task GetCrust_Valid_Scenario()
        {
            // Arrange
            var data = new List<Constituents>() {
             new Constituents(){
                 Id = 1,
                 Name ="Stuffed Crust",
             }};

            mockConstituentsRepository.Setup(x => x.GetConstituentByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(data);

            // Act
            var actualResult = await controller.GetCrust();

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task GetExtraCheese_Valid_Scenario()
        {
            // Arrange
            var data = new List<Constituents>() {
             new Constituents(){
                 Id = 1,
                 Name ="Cheese Burst",
             }};

            mockConstituentsRepository.Setup(x => x.GetConstituentByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(data);

            // Act
            var actualResult = await controller.GetExtraCheese();

            // Assert
            Assert.NotNull(actualResult);
        }
    }
}
