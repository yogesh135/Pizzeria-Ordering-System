using Pizzeria_Ordering_System.DataTransfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Repository.Interfaces
{
    public interface IConstituentsRepository
    {
        /// <summary>
        /// Get all constituents required in pizza making.
        /// </summary>
        /// <returns>List of Constituents</returns>
        Task<IEnumerable<Constituents>> GetAllConstituentsAsync();

        /// <summary>
        /// Get constituents based on Id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Constituent</returns>
        Task<Constituents> GetConstituentsByIdAsync(int id);

        /// <summary>
        /// Get Constituents Type
        /// </summary>
        /// <param name="typeId">type of constituents</param>
        /// <returns>List of constituents for a given type</returns>
        Task<IEnumerable<Constituents>> GetIngredientsByTypeIdAsync(int typeId);

        /// <summary>
        /// Get all constituents type.
        /// </summary>
        /// <returns>List of all constituents type.</returns>
        Task<IEnumerable<ConstituentsType>> GetAllIngredientTypesAsync();

        /// <summary>
        /// Get the size of the Pizza.
        /// </summary>
        /// <returns>Returns the size of pizza.</returns>
        Task<IEnumerable<PizzaSize>> GetSizeAsync();
    }
}
