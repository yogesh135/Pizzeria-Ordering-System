using Pizzeria_Ordering_System.DataTransfer.Enum;

namespace Pizzeria_Ordering_System.DataTransfer
{
    public class Constituents : BaseDto
    {
        /// <summary>
        /// Constituents Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constituents Type Id.
        /// </summary>
        public int ConstituentTypeId { get; set; }

        /// <summary>
        /// Constituents Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Recipe Type.
        /// </summary>
        public RecipeType RecipeType { get; set; }
    }
}
