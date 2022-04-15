using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.Persistence;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Repository.Implementations
{
    /// <summary>
    /// Constituent repository.
    /// </summary>
    public class ConstituentsRepository : IConstituentsRepository
    {
        /// <summary>
        /// Data store repo.
        /// </summary>
        private readonly IDataStoreRepository dataStoreRepository;

        /// <summary>
        /// Ctor for the initializing for data store repository.
        /// </summary>
        /// <param name="dataStoreRepository"></param>
        public ConstituentsRepository(IDataStoreRepository dataStoreRepository)
        {
            this.dataStoreRepository = dataStoreRepository;
        }

        /// <summary>
        /// Get All Constituents.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Constituents>> GetAllConstituentsAsync()
        {
            return from constituents in await this.dataStoreRepository.GetAllConstituentsAsync()
                    select new Constituents
                    {
                        Id = constituents.Id,
                        Name = constituents.Name,
                        Price = constituents.Price,
                        RecipeType = constituents.RecipeType,
                    };
        }

        /// <summary>
        /// Get All Constituent Types.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ConstituentsType>> GetAllConstituentTypesAsync()
        {
            return await this.dataStoreRepository.GetAllConstituentTypesAsync();
        }

        /// <summary>
        /// Get Constituents By Id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns></returns>
        public async Task<Constituents> GetConstituentsByIdAsync(int id)
        {
            return (from constituent in await this.dataStoreRepository.GetAllConstituentsAsync()
                   where id == constituent.Id
                   select new Constituents
                   {
                       Id = constituent.Id,
                       Name = constituent.Name,
                       Price = constituent.Price,
                       RecipeType = constituent.RecipeType,
                   }).FirstOrDefault();
        }

        /// <summary>
        /// Get Constituent By Type Id.
        /// </summary>
        /// <param name="typeId">TypeId</param>
        /// <returns></returns>
        public async Task<IEnumerable<Constituents>> GetConstituentByTypeIdAsync(int typeId)
        {
            return from constituent in await this.dataStoreRepository.GetAllConstituentsAsync()
                    where typeId == constituent.ConstituentTypeId
                    select new Constituents
                    {
                        Id = constituent.Id,
                        Name = constituent.Name,
                        Price = constituent.Price,
                        RecipeType = constituent.RecipeType,
                    };
        }

        /// <summary>
        /// Get Pizza Size.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PizzaSize>> GetPizzaSizeAsync()
        {
            return from pizzaSize in await this.dataStoreRepository.GetPizzaSizeAsync()
                   select new PizzaSize
                   {
                       Id = pizzaSize.Id,
                       Name = pizzaSize.Name,
                   };
        }
    }
}
