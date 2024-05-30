﻿using AutoMapper;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
        }
    }
}