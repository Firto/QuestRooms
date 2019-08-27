using QuestRooms.BLL.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.BLL.Servises.Abstraction
{
    public interface ICityService
    {
        ICollection<CityDto> GetAllCities();
    }
}
