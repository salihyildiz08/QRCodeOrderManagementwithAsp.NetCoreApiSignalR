using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationsController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll());
			return Ok(values);
		}


		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			var values = _notificationService.TNotificationCountByStatusFalse();
			return Ok(values);
		}

        [HttpGet("NotificationStatusChangeToTrue")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok();
        }

        [HttpGet("NotificationStatusChangeToFalse")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok();
        }



        [HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			var values = _notificationService.TGetAllNotificationByFalse();
			return Ok(values);
		}


		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{

			_notificationService.TAdd(new Notification()
			{
				Date = DateTime.Now,
				Description = createNotificationDto.Description,
				Type = createNotificationDto.Type,
				Status = true,
				Icon= createNotificationDto.Icon,
			});

			return Ok("Successfull");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			_notificationService.TDelete(value);
			return Ok("Delete Notification");
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			_notificationService.TUpdate(new Notification()
			{
				Type = updateNotificationDto.Type,
				Date = DateTime.Now,
				Description=updateNotificationDto.Description,
				NotificationID=updateNotificationDto.NotificationID,
				Status = updateNotificationDto.Status,
				Icon=updateNotificationDto.Icon,
			});
			return Ok("Update Notification");
		}

		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			return Ok(value);
		}


	}
}
