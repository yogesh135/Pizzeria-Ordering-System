using System.Collections.Generic;

namespace Pizzeria_Ordering_System.DataTransfer
{
    public class Pizza : BaseDto
    {
        /// <summary>
        /// Ctor of Pizza.
        /// </summary>
        public Pizza()
        {
            PizzaConstituents = new List<PizzaConstituents>();
        }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ImageUrl.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// SizeId.
        /// </summary>
        public int PizzaSizeId { get; set; }

        /// <summary>
        /// CategoriesId.
        /// </summary>
        public int CategoriesId { get; set; }

        /// <summary>
        /// IsAddCheese.
        /// </summary>
        public bool IsAddCheese { get; set; }

        /// <summary>
        /// IsAddExtraCheese.
        /// </summary>
        public bool IsAddExtraCheese { get; set; }

        /// <summary>
        /// Constituents collection.
        /// </summary>
        public IList<PizzaConstituents> PizzaConstituents { get; set; }
    }
}
