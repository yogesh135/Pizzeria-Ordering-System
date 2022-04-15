using Pizzeria_Ordering_System.DataTransfer.Enum;

namespace Pizzeria_Ordering_System.DataTransfer
{
    public class PizzaSize : BaseDto
    {
        /// <summary>
        /// Pizza Size Name.
        /// </summary>
        public SizeType Name { get; set; }

        /// <summary>
        /// Multiplier.
        /// </summary>
        public decimal Multiplier { get; set; }
    }
}
