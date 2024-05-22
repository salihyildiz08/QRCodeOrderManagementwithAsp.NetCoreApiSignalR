using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;



        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("TotaMenulTable")]
        public IActionResult TotaMenulTable()
        {
            var values = _menuTableService.TTotaMenulTable();
            return Ok(values);
        }



        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {

            _menuTableService.TAdd(new MenuTable()
            {
                Name = createMenuTableDto.Name,
                Status = true
            });

            return Ok("Successfull");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            _menuTableService.TDelete(value);
            return Ok("Delete MenuTable");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            _menuTableService.TUpdate(new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Status = updateMenuTableDto.Status,
                Name = updateMenuTableDto.Name
            });
            return Ok("Update MenuTable");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            return Ok(value);
        }


    }
}