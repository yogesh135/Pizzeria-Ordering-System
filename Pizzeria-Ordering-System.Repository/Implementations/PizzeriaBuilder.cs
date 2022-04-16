using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.Persistence;
using Pizzeria_Ordering_System.Repository.Interfaces;

namespace Pizzeria_Ordering_System.Repository.Implementations
{
    public class PizzeriaBuilder : IPizzeriaBuilder
    {
        Pizza pizza;
        private static int Id = 100;

        public void AddConstituentsToPizza(Constituents constituents)
        {
            if (constituents == null)
                return;

            this.pizza.PizzaConstituents.Add(new PizzaConstituents()
            {
                PizzaId = pizza.Id,
                ConstituentId = constituents.Id
            });

            this.pizza.Price += constituents.Price;
        }

        public void AddCountOfPizza(int number)
        {
            this.pizza.Price *= number;
        }

        public void AddExtraCheeseOnPizza()
        {
            pizza.IsAddExtraCheese = true;
            this.pizza.Price += PizzaConstants.ExtraCheesePrice;
        }

        public void AddPizzaCheese()
        {
            pizza.IsAddCheese = true;
            this.pizza.Price += PizzaConstants.CheesePrice;
        }

        public void AddPizzaSize(PizzaSize size)
        {
            if(size == null)
            {
                return;
            }

            this.pizza.PizzaSizeId = size.Id;
            this.pizza.Price *= size.Multiplier;
        }

        public Pizza BakePizza()
        {
            return this.pizza;
        }

        public void CreateAvailablePizza(Pizza pizza)
        {
            if(pizza == null)
            {
                return;
            }

            this.pizza = pizza;
        }

        public void CustomizedPizzaBase(string Name)
        {
            pizza = new Pizza();
            pizza.Name = Name;
            pizza.Id = Id++;
            pizza.Price = 110;
        }
    }
}
