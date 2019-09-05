using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Entities
{
    public class Country: BaseEntity
    {

        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
