using System.Collections.Generic;

namespace Pizzeria_Ordering_System.Contract
{
    public class PizzaOrderRequest
    {
        /// <summary>
        /// Name of Pizza.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Size of Pizza.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Number of Pizza's.
        /// </summary>
        public int NumberOfPizza { get; set; }

        /// <summary>
        /// Cheese Needed?.
        /// </summary>
        public bool IsAddCheese { get; set; }

        /// <summary>
        /// Extra Cheese Needed?.
        /// </summary>
        public bool IsAddExtraCheese { get; set; }

        /// <summary>
        /// Pizza Constituents Id.
        /// </summary>
        public IEnumerable<int> PizzaConstituentsId { get; set; }
    }
}
