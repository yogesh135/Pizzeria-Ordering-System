using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Repository.Implementations
{
    public class ConstituentsRepository : IConstituentsRepository
    {
        public Task<IEnumerable<Constituents>> GetAllConstituentsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ConstituentsType>> GetAllIngredientTypesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Constituents> GetConstituentsByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Constituents>> GetIngredientsByTypeIdAsync(int typeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PizzaSize>> GetSizeAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
