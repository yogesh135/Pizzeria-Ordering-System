using Pizzeria_Ordering_System.DataTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Persistence
{
    internal class SeedDataRepository : ISeedDataRepository
    {
        public IList<Categories> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Constituents> GetAllConstituents()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Constituents>> GetAllConstituentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConstituentsType>> GetAllConstituentTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PizzaSize>> GetAllPizzasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Constituents> GetConstituentByIdAsync(int constituentId)
        {
            throw new NotImplementedException();
        }

        public Task<PizzaSize> GetPizzaByIdAsync(int pizzaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PizzaSize>> GetPizzaSizeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PizzaSize> GetSizeByIdAsync(int sizeId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SavePizzaAsync(PizzaSize pizza)
        {
            throw new NotImplementedException();
        }
    }
}
