using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;



        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

       

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {

            _sliderService.TAdd(new Slider()
            {
                Title1 = createSliderDto.Title1,
                Description1 = createSliderDto.Description1,
                Description2 = createSliderDto.Description2,
                Description3 = createSliderDto.Description3,
                Title2 = createSliderDto.Title2,
                Title3 = createSliderDto.Title3,
            });

            return Ok("Successfull");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Delete Slider");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                Title1 = updateSliderDto.Title1,
                Description1 = updateSliderDto.Description1,
                Description2 = updateSliderDto.Description2,
                Description3 = updateSliderDto.Description3,
                Title2 = updateSliderDto.Title2,
                Title3 = updateSliderDto.Title3,
                SliderID=updateSliderDto.SliderID
            });
            return Ok("Update Slider");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(value);
        }


    }
}
