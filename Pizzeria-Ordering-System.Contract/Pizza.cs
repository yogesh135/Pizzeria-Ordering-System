using System.Collections.Generic;

namespace Pizzeria_Ordering_System.Contract
{
    public class Pizza
    {
        public Pizza()
        {
            Constituents = new List<Constituents>();
        }

        /// <summary>
        /// Constituents Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Constituents Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constituents Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Constituents description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Constituents Image Url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Constituents.
        /// </summary>
        public IEnumerable<Constituents> Constituents { get; set; }
    }
}
