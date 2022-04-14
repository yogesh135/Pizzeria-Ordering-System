using Microsoft.AspNetCore.Mvc;
using Pizzeria_Ordering_System.Repository.Interfaces;

namespace Pizzeria_Ordering_System.Controllers
{
    public class ConstituentsController : ControllerBase
    {
        private readonly IConstituentsRepository constituentsRepository;

        public ConstituentsController(IConstituentsRepository constituentsRepository)
        {
            this.constituentsRepository = constituentsRepository;
        }
    }
}
