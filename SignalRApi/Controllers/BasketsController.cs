using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Concrete;
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

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {


            using var context=new SignalRContext();
            var menuTable = context.MenuTables.FirstOrDefault(x=>x.Status==true);

            _basketService.TUpdateOrCreateBasketCount(new Basket()
            {
               Count=1,
               MenuTableID=1,
               Price=context.Products.Where(x=>x.ProductID==createBasketDto.ProductID).Select(y=>y.Price).FirstOrDefault(),
               ProductID = createBasketDto.ProductID,
               TotalPrice = 0
            });

            return Ok("Successfull");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Delete Basket");
        }
    }
}
