using Pizzeria_Ordering_System.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Repository.Interfaces
{
    public interface IPizzaOrderRepository
    {
        /// <summary>
        /// Get Pizza Order.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pizza>> GetOrderedPizzaAsync();

        /// <summary>
        /// Get Side Order.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SideBeverages>> GetOrderedSideBeverageAsync();

        /// <summary>
        /// Get Pizza  by Id.
        /// </summary>
        /// <param name="Id">Pizza Id.</param>
        /// <returns></returns>
        Task<Pizza> GetPizzaByIdAsync(int pizzaId);

        /// <summary>
        /// Create custom pizza.
        /// </summary>
        /// <param name="request">pizza request object.</param>
        /// <returns></returns>
        Task<PizzaOrderResponse> CustomizedPizzaOrder(PizzaOrderRequest request);

        /// <summary>
        /// Create normal pizza.
        /// </summary>
        /// <param name="request">pizza request object.</param>
        /// <param name="pizzaId">pizza id.</param>
        /// <returns></returns>
        Task<PizzaOrderResponse> CreatePizzaOrder(PizzaOrderRequest request, int pizzaId);

    }
}
