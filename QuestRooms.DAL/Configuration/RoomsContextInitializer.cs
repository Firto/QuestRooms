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
            "/MockData/DBInit.sql",
            "/MockData/DBInit.sql"
        };

        protected override void Seed(RoomsContext db)
        {
            //using (FileStream file = new FileStream("Configuration/DBInit.sql", FileMode.Open, FileAccess.Read)) {
            //    byte[] bytes = new byte[file.Length+1];
            //    file.Read(bytes, 0, (int)file.Length);
            //    db.Database.ExecuteSqlCommand(BitConverter.ToString(bytes));
            //    db.SaveChanges();
            //}

            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var path in paths)
            {
                if (File.Exists(buildDir + path))
                    db.Database.ExecuteSqlCommand(ReadFromFile(buildDir + path));
            }
        }

        private string ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
