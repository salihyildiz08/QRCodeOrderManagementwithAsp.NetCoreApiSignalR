﻿using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLAyer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;



        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _contactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {

            _contactService.TAdd(new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail=createContactDto.Mail,
                Phone=createContactDto.Phone,
                FooterTitle=createContactDto.FooterTitle,
                OpenDays=createContactDto.OpenDays,
                OpenDaysDescription=createContactDto.OpenDaysDescription,
                OpenHours=createContactDto.OpenHours,
            });

            return Ok("Successfull");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("Delete Contact");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
               ContactID = updateContactDto.ContactID,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone,
                FooterTitle = updateContactDto.FooterTitle,
                OpenDays = updateContactDto.OpenDays,
                OpenDaysDescription = updateContactDto.OpenDaysDescription,
                OpenHours = updateContactDto.OpenHours,
            });
            return Ok("Update Contact");
        }

		[HttpGet("{id}")]
		public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }
    }
}