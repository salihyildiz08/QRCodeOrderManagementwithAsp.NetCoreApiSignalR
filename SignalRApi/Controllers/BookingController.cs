using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;


        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

      

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
           

            
                _bookingService.TAdd(new Booking()
                {
                    Date = DateTime.Now,
                    Mail=createBookingDto.Mail,
                    Name = createBookingDto.Name,
                    PersonCount=createBookingDto.PersonCount,
                    Phone=createBookingDto.Phone,
                });
           
            return Ok("Successfull");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Delete Booking");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            _bookingService.TUpdate(new Booking(){
                BookingID = updateBookingDto.BookingID,
                Mail = updateBookingDto.Mail,
                Phone = updateBookingDto.Phone,
                PersonCount=updateBookingDto.PersonCount,
                Name=updateBookingDto.Name,
            });
            return Ok();
        }

		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
    }
}
 