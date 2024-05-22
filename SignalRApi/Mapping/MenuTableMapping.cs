using AutoMapper;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class MenuTableMapping:Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
        }
       
    }
}
