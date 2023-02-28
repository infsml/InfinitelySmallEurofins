using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLabs
{
    class DirectoryInfoStuff
    {
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo("something");
            info.Create();
            Console.WriteLine("Directory created");
            info.CreateSubdirectory("nothing");
            info.CreateSubdirectory("nothing1");
            info.CreateSubdirectory("nothing2");
            info.CreateSubdirectory("nothing3");
            Console.WriteLine("Subdirectory created");
            
        }
    }
}
