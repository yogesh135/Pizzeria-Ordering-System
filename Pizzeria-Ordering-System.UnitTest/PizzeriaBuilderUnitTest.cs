using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.DataTransfer.Enum;
using Pizzeria_Ordering_System.Repository.Implementations;
using Xunit;

namespace Pizzeria_Ordering_System.UnitTest
{
    public class PizzeriaBuilderUnitTest
    {
        public PizzeriaBuilder pizzeriaBuilder = null;
        
        public PizzeriaBuilderUnitTest()
        {
            pizzeriaBuilder = new PizzeriaBuilder();
        }

        /// <summary>
        /// Customized Pizza.
        /// </summary>
        [Fact]
        public void CreateCustomPizza()
        {
            // Arrange
            var pizzaSize = new PizzaSize();
            pizzaSize.Id = 1;
            pizzeriaBuilder.CustomizedPizzaBase("Custom");
            pizzeriaBuilder.AddCountOfPizza(1);
            pizzeriaBuilder.AddPizzaSize(pizzaSize);
            pizzeriaBuilder.AddExtraCheeseOnPizza();
            pizzeriaBuilder.AddPizzaSize(new PizzaSize() { Id = 1, Name = SizeType.Small, Multiplier = 1.5m });
            pizzeriaBuilder.AddConstituentsToPizza(new Constituents()
            {
                Id = 1,
                Name = "Grilled Mushrooms",
                RecipeType = RecipeType.Vegeterian,
                ConstituentTypeId = 3,
                Price = 60,
            });

            // Act
            var pizza = pizzeriaBuilder.BakePizza();

            // Assert
            Assert.NotNull(pizza);
        }
    }
}
