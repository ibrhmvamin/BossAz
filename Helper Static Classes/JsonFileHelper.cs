using BossAzFinalProject.Entity_Classes;
using Newtonsoft.Json;
using System.IO;

namespace BossAzFinalProject.Helper_Static_Classes
{
    public static class JsonFileHelper
    {
        public const string fileName = "database.json";
        public static void WriteToJson(Database database)
        {
            var serializer = new JsonSerializer();
            string CURRENT_PATH = Directory.GetCurrentDirectory();

            DirectoryInfo dir = new DirectoryInfo(CURRENT_PATH);
            CURRENT_PATH = dir.Parent.Parent.FullName;

            using (var sw = new StreamWriter(CURRENT_PATH + "/database.json"))
            {

                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    serializer.Serialize(jw, database, typeof(object));
                }
            }
        }

        public static Database ReadFromJson()
        {
            Database resultDatabase = null;
            var serializer = new JsonSerializer();
            string CURRENT_PATH = Directory.GetCurrentDirectory();

            DirectoryInfo dir = new DirectoryInfo(CURRENT_PATH);
            CURRENT_PATH = dir.Parent.Parent.FullName;

            using (var sr = new StreamReader(CURRENT_PATH + "/database.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    resultDatabase = serializer.Deserialize<Database>(jr);
                }
            }
            return resultDatabase;
        }

    }

}

