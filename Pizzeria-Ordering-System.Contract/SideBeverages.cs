using Pizzeria_Ordering_System.Contract.Enum;

namespace Pizzeria_Ordering_System.Contract
{
    public class SideBeverages
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

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
        public string BeverageType { get; set; }

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
