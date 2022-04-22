using Pizzeria_Ordering_System.Contract;
using Pizzeria_Ordering_System.Persistence;
using Pizzeria_Ordering_System.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzeria_Ordering_System.Persistence.CustomException;

namespace Pizzeria_Ordering_System.Repository.Implementations
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        /// <summary>
        /// Data Store Repository.
        /// </summary>
        private readonly IDataStoreRepository dataStoreRepository;

        /// <summary>
        /// Pizzeria Builder.
        /// </summary>
        private readonly IPizzeriaBuilder pizzeriaBuilder;

        /// <summary>
        /// OrderId
        /// </summary>
        public static int OrderId = 10;

        /// <summary>
        /// Ctor for Pizza Order repo.
        /// </summary>
        /// <param name="dataStoreRepository">Data Store Repository.</param>
        /// <param name="pizzeriaBuilder">Pizzeria Builder.</param>
        public PizzaOrderRepository(IDataStoreRepository dataStoreRepository,
            IPizzeriaBuilder pizzeriaBuilder)
        {
            this.dataStoreRepository = dataStoreRepository;
            this.pizzeriaBuilder = pizzeriaBuilder;
        }

        /// <summary>
        /// Create Pizza Order.
        /// </summary>
        /// <param name="request">Request Objevct.</param>
        /// <param name="pizzaId">Pizza Id.</param>
        /// <returns></returns>
        public async Task<PizzaOrderResponse> CreatePizzaOrder(PizzaOrderRequest request, int pizzaId)
        {
            if (pizzaId == 0)
            {
                throw new ArgumentNullException("Pizza Id is not valid, please enter a valid pizza Id");
            }

            var selectedPizza = await this.dataStoreRepository.GetPizzaByIdAsync(pizzaId);

            if (selectedPizza == null)
                throw new PizzaNotFoundException("selected pizza  not found");

            //Create Non-Customized Order.
            var pizza = await CreatePizza(request, selectedPizza);

            //Save pizza order
            await this.dataStoreRepository.SavePizzaAsync(pizza);

            return new PizzaOrderResponse()
            {
                OrderId = OrderId++,
                PizzaId = pizza.Id,
                PizzaName = pizza.Name,
                Count = request.NumberOfPizza,
                Price = pizza.Price
            };
        }

        /// <summary>
        /// Create Customized/Available Pizza.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="pizza">pizza.</param>
        /// <returns>Pizza.</returns>
        private async Task<DataTransfer.Pizza> CreatePizza(PizzaOrderRequest request, DataTransfer.Pizza pizza = null)
        {
            if (request == null)
                throw new ArgumentNullException("No valid request found for pizza, Please select valid pizza");

            if (pizza == null)
            {
                this.pizzeriaBuilder.CustomizedPizzaBase(request.Name);
            }
            else
            {
                this.pizzeriaBuilder.CreateAvailablePizza(pizza);
            }

            if (request.Size != 0)
            {
                var pizzaSize = await this.dataStoreRepository.GetSizeByIdAsync(request.Size);
                this.pizzeriaBuilder.AddPizzaSize(pizzaSize);
            }
            if (request.IsAddCheese)
            {
                this.pizzeriaBuilder.AddPizzaCheese();
            }
            if (request.IsAddExtraCheese)
            {
                this.pizzeriaBuilder.AddExtraCheeseOnPizza();
            }
            if (request.PizzaConstituentsId?.Any() == true)
            {
                foreach (var item in request.PizzaConstituentsId)
                {
                    var constituent = await this.dataStoreRepository.GetConstituentByIdAsync(item);
                    this.pizzeriaBuilder.AddConstituentsToPizza(constituent);

                }
            }
            if (request.NumberOfPizza != 0)
            {
                this.pizzeriaBuilder.AddCountOfPizza(request.NumberOfPizza);
            }
            return this.pizzeriaBuilder.BakePizza();
        }

        /// <summary>
        /// Customized Pizza Order.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns></returns>
        public async Task<PizzaOrderResponse> CustomizedPizzaOrder(PizzaOrderRequest request)
        {
            //create pizza
            var pizza = await this.CreatePizza(request);

            //Save pizza order
            await this.dataStoreRepository.SavePizzaAsync(pizza);

            return new PizzaOrderResponse()
            {
                OrderId = OrderId++,
                PizzaId = pizza.Id,
                PizzaName = pizza.Name,
                Count = request.NumberOfPizza,
                Price = pizza.Price
            };
        }

        /// <summary>
        /// Get Ordered Pizza.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Contract.Pizza>> GetOrderedPizzaAsync()
        {
            var result = (from pizza in await this.dataStoreRepository.GetAllPizzasAsync()
                          select new Contract.Pizza
                          {
                              Id = pizza.Id,
                              Name = pizza.Name,
                              ImageUrl = pizza.ImageUrl,
                              Description = pizza.Description,
                              Price = pizza.Price,
                              Constituents = (from constituent in this.dataStoreRepository.GetAllConstituents()
                              where pizza.PizzaConstituents.Select(item => item.ConstituentId).Contains(constituent.Id)
                                        select new Contract.Constituents
                                        {
                                            Id = constituent.Id,
                                            Name = constituent.Name,
                                            Price = constituent.Price
                                        }).ToList()
                          }).AsEnumerable();

            return result;
        }

        /// <summary>
        /// Get Ordered Pizza.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Contract.SideBeverages>> GetOrderedSideBeverageAsync()
        {
            var result = (from sideBeverage in await this.dataStoreRepository.GetAllSideBeveragesAsync()
                          select new Contract.SideBeverages
                          {
                              Id = sideBeverage.Id,
                              Name = sideBeverage.Name,
                              ImageUrl = sideBeverage.ImageUrl,
                              Description = sideBeverage.Description,
                              Price = sideBeverage.Price,
                              BeverageConstituents = sideBeverage.BeverageConstituents,
                              BeverageType = sideBeverage.BeverageType.ToString(),
                              CategoriesId = sideBeverage.CategoriesId
                          }).AsEnumerable();

            return result;
        }

        /// <summary>
        /// Get Pizza By Id.
        /// </summary>
        /// <param name="pizzaId">Pizza Id.</param>
        /// <returns></returns>
        public async Task<Contract.Pizza> GetPizzaByIdAsync(int pizzaId)
        {
            if(pizzaId == 0)
            {
                throw new ArgumentNullException("Pizza Id is not valid, please enter a valid pizza Id");
            }

            var result = (from pizza in await this.dataStoreRepository.GetAllPizzasAsync()
                          where pizza.Id == pizzaId
                          select new Contract.Pizza
                          {
                              Id = pizza.Id,
                              Description = pizza.Description,
                              ImageUrl = pizza.ImageUrl,
                              Name = pizza.Name,
                              Price = pizza.Price,
                              Constituents = (from constituents in this.dataStoreRepository.GetAllConstituents()
                              where pizza.PizzaConstituents.Select(item => item.ConstituentId).Contains(constituents.Id)
                                    select new Contract.Constituents
                                    {
                                        Id = constituents.Id,
                                        Name = constituents.Name,
                                        Price = constituents.Price
                                    }).ToList()
                          }).FirstOrDefault();
            
            return result;
        }
    }
}
