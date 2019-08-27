using AutoMapper;
using QuestRooms.BLL.DtoModels;
using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.BLL.Mapping
{
    public class MapperProflile : Profile
    {
        public MapperProflile()
        {
            CreateMap<City, CityDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Street, StreetDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<QuestRoom, QuestRoomDto>();
        }     
    }
}
