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
    public class QuestRoomServise : IQuestRoomService
    {
        private readonly IGenericRepository<QuestRoom> repos;
        private readonly IMapper mapper;
        public QuestRoomServise(IGenericRepository<QuestRoom> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }
        public ICollection<QuestRoomDto> GetAllRooms()
        {
            return mapper.Map<IEnumerable<QuestRoom>, ICollection<QuestRoomDto>>(repos.Get());
        }
    }
}
