using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangayrecordandmanagementSystem
{
    class dbconnection
    {
        public static string connection = System.IO.File.ReadAllText(System.Environment.CurrentDirectory + @"\config.txt");
    }
}
