using Moq;
using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.DataTransfer.Enum;
using Pizzeria_Ordering_System.Persistence;
using Pizzeria_Ordering_System.Repository.Implementations;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pizzeria_Ordering_System.UnitTest.Repository
{
    public class ConstituentsRepositoryUnitTest
    {
        public IConstituentsRepository constituentRepository = null;
        public Mock<IDataStoreRepository> mockDataStoreRespo = null;

        public ConstituentsRepositoryUnitTest()
        {
            mockDataStoreRespo = new Mock<IDataStoreRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            constituentRepository = new ConstituentsRepository(mockDataStoreRespo.Object);
        }

        [Fact]
        public async Task GetAllConstituentsAsync_ValidData_Success()
        {
            // Arrange
            var data = new List<Constituents>() {
                 new Constituents() {
                     Id = 1,
                     Name ="Green Capsicum",
                     RecipeType = RecipeType.Vegeterian,
                     ConstituentTypeId = 1,
                     Price = 60,
                 }
            };

            this.mockDataStoreRespo.Setup(x => x.GetAllConstituentsAsync()).ReturnsAsync(data);

            // Act
            var result = await constituentRepository.GetAllConstituentsAsync().ConfigureAwait(false);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllConstituentTypesAsync_ValidData_Success()
        {
            // Arrange
            var data = new List<ConstituentsType>() {
             new ConstituentsType(){
                 Id = 1,
                 Name = "Crust"
             }
            };

            mockDataStoreRespo.Setup(x => x.GetAllConstituentTypesAsync()).ReturnsAsync(data);

            // Act
            var result = await constituentRepository.GetAllConstituentTypesAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetConstituentsByIdAsync_ValidData_Success()
        {
            // Arrange
            var data = new List<Constituents>() {
                 new Constituents() {
                     Id = 1,
                     Name ="Green Capsicum",
                     RecipeType = RecipeType.Vegeterian,
                     ConstituentTypeId = 1,
                     Price = 60,
                 }
            };

            mockDataStoreRespo.Setup(x => x.GetAllConstituentsAsync()).ReturnsAsync(data);

            // Act
            var result = await constituentRepository.GetConstituentsByIdAsync(1);

            // Assert
            Assert.Equal(result.Price, data[0].Price);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetConstituentByTypeIdAsync_InValidData_Failure()
        {
            // Arrange
            var data = new List<Constituents>() {
                 new Constituents() {
                     Id = 1,
                     Name ="Green Capsicum",
                     RecipeType = RecipeType.Vegeterian,
                     ConstituentTypeId = 1,
                     Price = 60,
                 }
            };

            mockDataStoreRespo.Setup(x => x.GetAllConstituentsAsync()).ReturnsAsync(data);

            // Act
            var result = await constituentRepository.GetConstituentByTypeIdAsync(2);

            // Assert
            Assert.Null(result.FirstOrDefault());
        }

        [Fact]
        public async Task GetConstituentByTypeIdAsync_ValidData_Success()
        {
            // Arrange
            var data = new List<Constituents>() {
                 new Constituents() {
                     Id = 1,
                     Name ="Green Capsicum",
                     RecipeType = RecipeType.Vegeterian,
                     ConstituentTypeId = 1,
                     Price = 60,
                 }
            };

            mockDataStoreRespo.Setup(x => x.GetAllConstituentsAsync()).ReturnsAsync(data);

            // Act
            var result = await constituentRepository.GetConstituentByTypeIdAsync(1);

            // Assert
            Assert.Equal(result.FirstOrDefault().Name, data[0].Name);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetPizzaSizeAsync_ValidData_Success()
        {
            // Arrange
            var data = new List<PizzaSize>() {
                 new PizzaSize() {
                    Id = 2,
                    Multiplier = 2m,
                    Name = SizeType.Medium
                 }
            };

            mockDataStoreRespo.Setup(x => x.GetPizzaSizeAsync()).ReturnsAsync(data);

            // Act
            var result = await constituentRepository.GetPizzaSizeAsync();

            // Assert
            Assert.Equal(result.FirstOrDefault().Name, data[0].Name);
            Assert.NotNull(result);
        }
    }
}
