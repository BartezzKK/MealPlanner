using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Tools
{
    public class PathDB
    {
        public static string GetPath(string dbName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dbName);
            #if WINDOWS || IOS
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbPath);
            #endif 
            return dbPath;
        }
    }
}
