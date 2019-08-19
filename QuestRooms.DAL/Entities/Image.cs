using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Entities
{
    public class Image
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual QuestRoom QuestRoom { get; set; } 
    }
}
