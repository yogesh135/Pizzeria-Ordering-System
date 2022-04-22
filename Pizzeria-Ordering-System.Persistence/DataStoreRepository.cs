using Pizzeria_Ordering_System.DataTransfer;
using Pizzeria_Ordering_System.DataTransfer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_Ordering_System.Persistence
{
    /// <summary>
    /// Seed Data class for Initializing pizzeria application.
    /// </summary>
    public class DataStoreRepository : IDataStoreRepository
    {
        public List<PizzaSize> pizzaSize;
        public List<Pizza> pizza;
        public List<SideBeverages> sideBeverages;
        public List<Constituents> constituents;

        public DataStoreRepository()
        {
            pizzaSize = new List<PizzaSize>();
            pizza = new List<Pizza>();
            constituents = new List<Constituents>();
            sideBeverages = new List<SideBeverages>();
            // Load seed data for the application.
            LoadSeedData();
        }

        private void LoadSeedData()
        {
            LoadSeedPizza();
            GetAllConstituentsAsync();
            GetAllConstituentTypesAsync();
            GetAllPizzasAsync();
            GetPizzaSizeAsync();
            LoadSideBeverages();
        }

        private void LoadSeedPizza()
        {
            pizza.AddRange(new List<Pizza>
            {
                new Pizza
                {
                    Id = 1,
                    Name = "Veggie Dhamaka",
                    Description = "Veggie Pizza for vegetarians with normal crust and Sauces",
                    Price = 150,
                    ImageUrl = "https://www.dominos.co.in/files/items/Deluxe_Veggie.jpg",
                    CategoriesId = 1, //Standard
                    PizzaConstituents = new List<PizzaConstituents>()
                    {
                        new PizzaConstituents()
                        {
                            ConstituentId = 1, // Green Capsicum, Veg, Sauces, Rs 60/-
                            PizzaId = 1
                        }
                    }
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Customized Pizza",
                    Description = "Veg Customized Pizza with cheese burst and thin crust",
                    Price = 220,
                    ImageUrl = "https://www.dominos.co.in/files/items/Digital_Veggie_Paradise_olo_266x265.jpg",
                    CategoriesId = 2, //Customized
                    IsAddCheese = true,
                    IsAddExtraCheese = true,
                    PizzaConstituents = new List<PizzaConstituents>()
                    {
                        new PizzaConstituents()
                        {
                            ConstituentId = 2,
                            PizzaId = 2,
                        }
                    }
                }
            });
        }

        private void LoadSideBeverages()
        {
            sideBeverages.AddRange(new List<SideBeverages>
            {
                new SideBeverages
                {
                    Id = 3,
                    Name = "Garlic Bread Stick",
                    Description = "The endearing tang of garlic in breadstics baked to perfection.",
                    CategoriesId= 1,
                    BeverageType = BeverageType.GarlicBreadStick,
                    BeverageConstituents = "Garlic Bread Stick, Coke, With Cheese",
                    ImageUrl = "https://api.pizzahut.io/v1/content/en-in/in-1/images/side/garlic-bread-stix.483aa904aa663102c645ce56261d360d.1.jpg?width=375",
                    Price = 110
                },
                new SideBeverages
                {
                    Id = 4,
                    Name = "Stuffed Garlic Bread",
                    Description = "Freshly Baked Garlic Bread stuffed with mozzarella cheese",
                    CategoriesId= 2,
                    BeverageType = BeverageType.StuffedGarlicBread,
                    BeverageConstituents = "Garlic Bread Stickmozzarella cheese, sweet corns, tangy, spicy jalapeños",
                    ImageUrl = "https://api.pizzahut.io/v1/content/en-in/in-1/images/side/mexican-garlic-breadstix-single.eab1259910d7d29cdba8ceb2e1b36355.1.jpg?width=375",
                    Price = 150
                }
            });
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return new List<Categories>
            {
                new Categories{Id = 1, Name = "Standard"},
                new Categories{Id = 2, Name = "Customized"}
            };
        }

        public IEnumerable<Constituents> GetAllConstituents()
        {
            constituents = new List<Constituents>() {
             new Constituents(){
                 Id = 1,
                 Name ="Green Capsicum",
                 RecipeType = RecipeType.Vegeterian,
                 ConstituentTypeId = 3,
                 Price = 60,
             },
             new Constituents(){
                 Id = 2,
                 Name ="Onion",
                 RecipeType = RecipeType.Vegeterian,
                 ConstituentTypeId = 3,
                 Price = 60,

             },
             new Constituents(){
                 Id = 3,
                 Name ="Spiced Paneer",
                 RecipeType = RecipeType.Vegeterian,
                 ConstituentTypeId = 4,
                 Price = 60,

             },
             new Constituents(){
                 Id = 3,
                 Name ="Chicken Meatball",
                 RecipeType = RecipeType.NonVegeterian,
                 ConstituentTypeId = 3,
                 Price = 120,

             },
             new Constituents(){
                 Id = 4,
                 Name ="Herbed Chicken",
                 RecipeType = RecipeType.NonVegeterian,
                 ConstituentTypeId = 3,
                 Price = 120,

             },
             new Constituents(){
                 Id = 4,
                 Name ="Peri Peri Chicken",
                 RecipeType = RecipeType.NonVegeterian,
                 ConstituentTypeId = 4,
                 Price = 150,

             },
             new Constituents(){
                 Id = 5,
                 Name ="Black Olives",
                 RecipeType = RecipeType.Vegeterian,
                 ConstituentTypeId = 1,
                 Price = 90,

             },
              new Constituents(){
                 Id = 6,
                 Name ="Stuffed Crust",
                 RecipeType = RecipeType.Vegeterian,
                 ConstituentTypeId = 1,
                 Price = 120,

             },
            new Constituents(){
                 Id = 7,
                 Name ="Sweet Corn",
                 RecipeType = RecipeType.Vegeterian,
                 ConstituentTypeId = 2,
                 Price = 90,

             },
            new Constituents(){
                 Id = 8,
                 Name ="Red Paprika",
                 RecipeType = RecipeType.Vegeterian,
                 ConstituentTypeId = 2,
                 Price = 60,

             }
            };

            return constituents;
        }

        public Task<IEnumerable<Constituents>> GetAllConstituentsAsync()
        {
            return Task.FromResult(GetAllConstituents());
        }

        public Task<IEnumerable<ConstituentsType>> GetAllConstituentTypesAsync()
        {
            var constituents = new List<ConstituentsType>
            {
                new ConstituentsType
                {
                    Id = 1,
                    Name = "Crust"
                },

                new ConstituentsType
                {
                    Id = 2,
                    Name = "Toppings"
                },

                new ConstituentsType
                {
                    Id = 3,
                    Name = "Sauces"
                },

                new ConstituentsType
                {
                    Id = 4,
                    Name = "Extra Cheese"
                },
            };

            return Task.FromResult(constituents.AsEnumerable());
        }

        public Task<IEnumerable<Pizza>> GetAllPizzasAsync()
        {
            return Task.FromResult(pizza.AsEnumerable());
        }

        public Task<IEnumerable<SideBeverages>> GetAllSideBeveragesAsync()
        {
            return Task.FromResult(sideBeverages.AsEnumerable());
        }

        public Task<Constituents> GetConstituentByIdAsync(int constituentId)
        {
            if (constituentId == 0)
            {
                throw new ArgumentNullException("ConstituentId is not valid, Please send correct Id");
            }

            var result = constituents.Where(x => x.Id == constituentId).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<Pizza> GetPizzaByIdAsync(int pizzaId)
        {
            if (pizzaId == 0)
            {
                throw new ArgumentNullException("PizzaId is not valid, Please send correct Id");
            }

            var result = pizza.Where(x => x.Id == pizzaId).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<PizzaSize>> GetPizzaSizeAsync()
        {
            pizzaSize = new List<PizzaSize>()
            {
                new PizzaSize
                {
                    Id = 1,
                    Multiplier = 1,
                    Name = SizeType.Small
                },
                new PizzaSize
                {
                    Id = 2,
                    Multiplier = 2m,
                    Name = SizeType.Medium
                },
                new PizzaSize
                {
                    Id = 3,
                    Multiplier = 3m,
                    Name = SizeType.Large
                },
            };

            return Task.FromResult(pizzaSize.AsEnumerable());
        }

        public Task<PizzaSize> GetSizeByIdAsync(int sizeId)
        {
            if (sizeId == 0)
            {
                throw new ArgumentNullException("SizeId is not valid, Please enter valid Id");
            }

            var result = pizzaSize.Where(x => x.Id == sizeId).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<int> SavePizzaAsync(Pizza pizzas)
        {
            if (pizzas == null)
            {
                throw new ArgumentNullException("Saved pizza is not valid, please save with correct pizza");
            }

            pizza.Add(pizzas);

            return Task.FromResult(pizzas.Id);
        }
    }
}
