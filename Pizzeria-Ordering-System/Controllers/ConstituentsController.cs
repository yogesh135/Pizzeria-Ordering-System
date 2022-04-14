using Microsoft.AspNetCore.Mvc;
using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Constituents")]
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

        [HttpGet]
        [Route("{constituentId}")]
        public async Task<Constituents> GetConstituentById([FromRoute] int constituentId)
        {
            var result = await this.constituentsRepository.GetConstituentsByIdAsync(constituentId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("types")]
        public async Task<IEnumerable<ConstituentsType>> GetAllConstituentsType()
        {
            return await this.constituentsRepository.GetAllConstituentTypesAsync();
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Toppings")]
        public async Task<IEnumerable<Constituents>> GetToppings()
        {
            return await _ingredientRepository.GetIngredientsByTypeIdAsync(3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Sauce")]
        public async Task<IEnumerable<Constituents>> GetPizzaSauce()
        {
            return await _ingredientRepository.GetIngredientsByTypeIdAsync(2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Crust")]
        public async Task<IEnumerable<Constituents>> GetCrust()
        {
            return await _ingredientRepository.GetIngredientsByTypeIdAsync(1);
        }
    }
}
