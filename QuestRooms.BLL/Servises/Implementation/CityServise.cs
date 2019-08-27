using AutoMapper;
using QuestRooms.BLL.DtoModels;
using QuestRooms.BLL.Servises.Abstraction;
using QuestRooms.DAL.Entities;
using QuestRooms.DAL.Repositoriy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.BLL.Servises.Implementation
{
    public class CityServise : ICityService
    {
        private readonly IGenericRepository<City> repos;
        private readonly IMapper mapper;
        public CityServise(IGenericRepository<City> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }
        public ICollection<CityDto> GetAllCities()
        {
            return mapper.Map<IEnumerable<City>, ICollection<CityDto>>(repos.Get());
        }
    }
}
