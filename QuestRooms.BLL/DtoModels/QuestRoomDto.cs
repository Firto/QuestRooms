using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.BLL.DtoModels
{
    public class QuestRoomDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan TimeTravel { get; set; }
        public short MinPlayers { get; set; }
        public short MaxPlayers { get; set; }
        public short MaxPlayerAge { get; set; }
        public AddressDto Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public CompanyDto Company { get; set; }
        public byte Rating { get; set; }
        public byte FearLevel { get; set; } // уровень страха
        public byte DifficultLevel { get; set; } // уровень сложности
        public float Price { get; set; }
        public ICollection<ImageDto> Images { get; set; }
    }
}
