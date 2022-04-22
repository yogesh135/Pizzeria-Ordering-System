using Microsoft.AspNetCore.Mvc;
using Pizzeria_Ordering_System.Contract;
using Pizzeria_Ordering_System.Persistence.CustomException;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pizza")]
    [ApiController]
    public class PizzaOrderController : ControllerBase
    {
        private readonly IPizzaOrderRepository pizzaOrderRepository;

        public PizzaOrderController(IPizzaOrderRepository pizzaOrderRepository)
        {
            this.pizzaOrderRepository = pizzaOrderRepository;
        }

        /// <summary>
        /// Get All Pizzas.
        /// </summary>
        /// <returns>List of Pizzas.</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            var result = await this.pizzaOrderRepository.GetOrderedPizzaAsync();
            return result;
        }

        /// <summary>
        /// Get All Pizzas.
        /// </summary>
        /// <returns>List of Pizzas.</returns>
        [HttpGet]
        [Route("getAllSideBeverages")]
        public async Task<IEnumerable<SideBeverages>> GetAllSideBeverages()
        {
            var result = await this.pizzaOrderRepository.GetOrderedSideBeverageAsync();
            return result;
        }

        /// <summary>
        /// Get Pizza By Id
        /// </summary>
        /// <param name="pizzaId">pizza id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pizzaId}")]
        public async Task<Pizza> GetPizzaById([FromRoute] int pizzaId)
        {
            var result = await this.pizzaOrderRepository.GetPizzaByIdAsync(pizzaId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("customPizza")]
        public async Task<IActionResult> BakeCustomizedPizza([FromBody] PizzaOrderRequest request)
        {
            try
            {
                var result = await this.pizzaOrderRepository.CustomizedPizzaOrder(request);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        /// <summary>
        /// Bake available pizza.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="pizzaId">pizzaId.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("avlblPizza/{pizzaId}")]
        public async Task<IActionResult> BakePizza([FromBody] PizzaOrderRequest request, [FromRoute] int pizzaId)
        {
            try
            {
                var result = await this.pizzaOrderRepository.CreatePizzaOrder(request, pizzaId);
                return Ok(result);
            }
            catch (PizzaNotFoundException)
            {
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
