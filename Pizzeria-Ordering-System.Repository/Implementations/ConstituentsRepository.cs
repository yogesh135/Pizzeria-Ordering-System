using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.Persistence;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Repository.Implementations
{
    public class ConstituentsRepository : IConstituentsRepository
    {
        private readonly ISeedDataRepository seedDataRepository;

        public ConstituentsRepository(ISeedDataRepository seedDataRepository)
        {
            this.seedDataRepository = seedDataRepository;
        }

        public Task<IEnumerable<Constituents>> GetAllConstituentsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ConstituentsType>> GetAllConstituentTypesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Constituents> GetConstituentsByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Constituents>> GetConstituentByTypeIdAsync(int typeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PizzaSize>> GetPizzaSizeAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
