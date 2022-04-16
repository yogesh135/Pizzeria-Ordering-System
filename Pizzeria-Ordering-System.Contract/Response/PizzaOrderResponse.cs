namespace Pizzeria_Ordering_System.Contract
{
    public class PizzaOrderResponse
    {
        /// <summary>
        /// Pizza Order Id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Pizza Id.
        /// </summary>
        public int PizzaId { get; set; }

        /// <summary>
        /// Name of Pizza.
        /// </summary>
        public string PizzaName { get; set; }

        /// <summary>
        /// Number of Pizza's.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Price of Pizza's.
        /// </summary>
        public decimal Price { get; set; }
    }
}
