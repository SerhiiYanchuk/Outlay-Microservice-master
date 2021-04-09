using CardMicroservice.UoW;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CardMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankCardsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankCardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}", Name = "Get" )]
        public IActionResult Get(int id)
        {
            try
            {
                var card = _unitOfWork.Cards.Get(id);
                if (card == null)
                    return new NotFoundResult();

                return new OkObjectResult(card);
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        [Route("/userscard")]
        [HttpGet]
        public IActionResult Get([FromBody] string login)
        {
            try
            {
                var cards = _unitOfWork.Cards.Find(x => x.User.Login == login);
                if (cards == null)
                    return new NotFoundResult();

                return new OkObjectResult(cards);
            }
            catch
            {
                return new BadRequestResult();
            }
        }

    }
}
