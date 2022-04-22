using Pizzeria_Ordering_System.DataTransfer.Enum;
using System.Collections.Generic;

namespace Pizzeria_Ordering_System.DataTransfer
{
    public class SideBeverages : BaseDto
    {
        ///// <summary>
        ///// Ctor of Pizza.
        ///// </summary>
        //public SideBeverages()
        //{
        //    PizzaConstituents = new List<PizzaConstituents>();
        //}

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
        public BeverageType BeverageType { get; set; }

        /// <summary>
        /// CategoriesId.
        /// </summary>
        public int CategoriesId { get; set; }

        /// <summary>
        /// Constituents collection.
        /// </summary>
        public string BeverageConstituents { get; set; }
    }
}
