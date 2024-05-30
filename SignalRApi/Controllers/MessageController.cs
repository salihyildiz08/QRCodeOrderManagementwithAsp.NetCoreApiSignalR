using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;


        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {



            _messageService.TAdd(new Message()
            {
                MessageSendDate = DateTime.Now,
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                Status = false,
                Subject = createMessageDto.Subject
               
            });

            return Ok("Successfull");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Delete Message");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _messageService.TUpdate(new Message()
            {
                MessageID = updateMessageDto.MessageID,
                Mail = updateMessageDto.Mail,
                Phone = updateMessageDto.Phone,
                Subject = updateMessageDto.Subject,
                Status = updateMessageDto.Status,
                NameSurname= updateMessageDto.NameSurname,
                MessageContent= updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate

            });
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }


       



    }
}
