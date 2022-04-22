using Pizzeria_Ordering_System.DataTransfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Persistence
{
    public interface IDataStoreRepository
    {
        /// <summary>
        /// Get All Pizzas.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pizza>> GetAllPizzasAsync();

        /// <summary>
        /// Get All Pizzas.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SideBeverages>> GetAllSideBeveragesAsync();

        /// <summary>
        /// Get Pizza by Id
        /// </summary>
        /// <returns></returns>
        Task<Pizza> GetPizzaByIdAsync(int pizzaId);

        /// <summary>
        /// Save Pizza's
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns></returns>
        Task<int> SavePizzaAsync(Pizza pizza);

        /// <summary>
        /// Get All the constituents.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Constituents> GetAllConstituents();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Constituents>> GetAllConstituentsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<Constituents> GetConstituentByIdAsync(int constituentId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ConstituentsType>> GetAllConstituentTypesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PizzaSize>> GetPizzaSizeAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<PizzaSize> GetSizeByIdAsync(int sizeId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Categories> GetAllCategories();
    }
}
