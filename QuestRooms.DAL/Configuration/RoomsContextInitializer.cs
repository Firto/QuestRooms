using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Configuration
{
    class RoomsContextInitializer : DropCreateDatabaseAlways<RoomsContext>
    {
        private List<string> paths = new List<string>
        {
            @"\bin\MockData\Countries.sql",
            @"\bin\MockData\Cities.sql",
            @"\bin\MockData\Streets.sql",
            @"\bin\MockData\Companies.sql",
            @"\bin\MockData\Addreses.sql",
            @"\bin\MockData\QuestRooms.sql"
        };

        protected override void Seed(RoomsContext db)
        {
            var buildDir = System.AppDomain.CurrentDomain.BaseDirectory;

            foreach (var path in paths)
            {
                if (File.Exists(buildDir + path))
                    db.Database.ExecuteSqlCommand(ReadFromFile(buildDir + path));
            }
        }

        private string ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
                return sr.ReadToEnd();
        }
    }
}
