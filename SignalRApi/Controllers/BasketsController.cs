using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketByTableID(int id) {
            var values = _basketService.TGetBasketByTableNumber(id);
            return Ok(values);

        }

        [HttpGet("BasketListByMenuTableWithPrudctName")]
        public IActionResult BasketListByMenuTableWithPrudctName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(x => x.MenuTableID == id)
                .Select(z => new ResultBasketListByMenuTableWithPrudcts
                {
                    MenuTableID = z.MenuTableID,
                    BasketID = z.BasketID,
                    Count = z.Count,
                    Price = z.Price,
                    ProductID = z.ProductID,
                    TotalPrice = z.TotalPrice,
                    ProductName= z.Product.ProductName
                }).ToList();
            return Ok(values);
        }
    }
}
