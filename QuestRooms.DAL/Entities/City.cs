using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
