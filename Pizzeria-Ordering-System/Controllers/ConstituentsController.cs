using Microsoft.AspNetCore.Mvc;
using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/constituents")]
    [ApiController]
    public class ConstituentsController : ControllerBase
    {
        private readonly IConstituentsRepository constituentsRepository;

        public ConstituentsController(IConstituentsRepository constituentsRepository)
        {
            this.constituentsRepository = constituentsRepository;
        }

        /// <summary>
        /// Gets all Constituents for a pizza.
        /// </summary>
        /// <returns>constituents.</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IEnumerable<Constituents>> GetAllConstituents()
        {
            var result = await this.constituentsRepository.GetAllConstituentsAsync();
            return result;
        }

        /// <summary>
        /// GetConstituentById.
        /// </summary>
        /// <param name="constituentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{constituentId}")]
        public async Task<Constituents> GetConstituentById([FromRoute] int constituentId)
        {
            var result = await this.constituentsRepository.GetConstituentsByIdAsync(constituentId);
            return result;
        }

        /// <summary>
        /// GetAllConstituentsType.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("types")]
        public async Task<IEnumerable<ConstituentsType>> GetAllConstituentsType()
        {
            return await this.constituentsRepository.GetAllConstituentTypesAsync();
        }

        /// <summary>
        /// ConstituentType.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("type/{typeId}")]
        public async Task<IEnumerable<Constituents>> GetConstituentType([FromRoute] int typeId)
        {
            return await this.constituentsRepository.GetConstituentByTypeIdAsync(typeId);
        }

        /// <summary>
        /// size
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("size")]
        public async Task<IEnumerable<PizzaSize>> GetPizzaSize()
        {
            return await this.constituentsRepository.GetPizzaSizeAsync();
        }

        /// <summary>
        /// Toppings.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Toppings")]
        public async Task<IEnumerable<Constituents>> GetToppings()
        {
            return await this.constituentsRepository.GetConstituentByTypeIdAsync(2);
        }

        /// <summary>
        /// Sauce.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Sauce")]
        public async Task<IEnumerable<Constituents>> GetPizzaSauce()
        {
            return await this.constituentsRepository.GetConstituentByTypeIdAsync(3);
        }

        /// <summary>
        /// Crust.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Crust")]
        public async Task<IEnumerable<Constituents>> GetCrust()
        {
            return await this.constituentsRepository.GetConstituentByTypeIdAsync(1);
        }

        /// <summary>
        /// ExtraCheese.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ExtraCheese")]
        public async Task<IEnumerable<Constituents>> GetExtraCheese()
        {
            return await this.constituentsRepository.GetConstituentByTypeIdAsync(4);
        }
    }
}
