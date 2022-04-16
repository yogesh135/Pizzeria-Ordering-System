using Pizzeria_Ordering_System.DataTransfer;

namespace Pizzeria_Ordering_System.Repository.Interfaces
{
    public interface IPizzeriaBuilder
    {
        /// <summary>
        /// Customized Pizza Base.
        /// </summary>
        /// <param name="Name">Name of Pizza Base.</param>
        void CustomizedPizzaBase(string Name);

        /// <summary>
        /// Create Available Pizza.
        /// </summary>
        /// <param name="pizza">Pizza.</param>
        void CreateAvailablePizza(Pizza pizza);

        /// <summary>
        /// Add Cheese on a Pizza.
        /// </summary>
        void AddPizzaCheese();

        /// <summary>
        /// Add Extra Pizza Cheese.
        /// </summary>
        void AddExtraCheeseOnPizza();

        /// <summary>
        /// Add Size of Pizza.
        /// </summary>
        /// <param name="size">size.</param>
        void AddPizzaSize(PizzaSize size);

        /// <summary>
        /// Add Constituents To Pizza.
        /// </summary>
        /// <param name="constituents">constituents.</param>
        void AddConstituentsToPizza(Constituents constituents);

        /// <summary>
        /// Add Count of Pizza.
        /// </summary>
        /// <param name="number">number.</param>
        void AddCountOfPizza(int number);

        /// <summary>
        /// Bake Pizza.
        /// </summary>
        /// <returns>pizza.</returns>
        Pizza BakePizza();
    }
}
